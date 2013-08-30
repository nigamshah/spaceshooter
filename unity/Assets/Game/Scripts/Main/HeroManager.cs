using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Config), typeof(ScoreCalculator))]
public class HeroManager : MonoBehaviour {

	private const string SPAWN_POINT_TAG = "HeroSpawnPoint";

	public GameObject HeroTemplate;
	public float SpawnDelay = 0.5f;

	private ScoreCalculator m_scoreCalculator;
	private int m_livesRemaining = 0;
	private int m_score = 0;

	// Use this for initialization
	void Start() {
		m_scoreCalculator = GetComponent<ScoreCalculator>();
		SetLives(GetComponent<Config>().StartingLives);
		SetScore(0);
	}

	private void SpawnHero() {
		print("HeroManager.SpawnHero");
		// there must be at least 1
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(SPAWN_POINT_TAG);
		if (spawnPoints.Length == 0) {
			Debug.LogError("There must be at least one HeroSpawnPoint in the scene");
			return;
		}
		
		int spawnIndex = RandomGenerator.Random.Next(spawnPoints.Length);
		Vector3 position = spawnPoints[spawnIndex].transform.position;
		Quaternion rotation = spawnPoints[spawnIndex].transform.rotation; //  should be Quaternion.identity (aka "no rotation"), but just in case
		
		GameObject hero = (GameObject) Instantiate(HeroTemplate, position, rotation);
		hero.transform.parent = transform;
	}

	private void SpacecraftDestroyed(GameObject craft) {
		Spacecraft spacecraft = craft.GetComponent<Spacecraft>();

		if (spacecraft == null) {
			Debug.LogError("craft parameter has no Spacecraft component, name = " + craft.name);
		}

		if (spacecraft.SpacecraftType == SpacecraftType.Hero) {
			AddLives(-1);
			if (m_livesRemaining == 0) {
				SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
			} else {
				Invoke("SpawnHero", SpawnDelay);
			}
		} else {
			string type = spacecraft.SpacecraftType.ToString();
			int score = m_scoreCalculator.GetScore(type);
			AddScore(score);
		}
	}

	private void SetLives(int lives) {
		m_livesRemaining = lives;
		SendMessage("LivesUpdated", m_livesRemaining, SendMessageOptions.DontRequireReceiver);
	}

	private void AddLives(int numToAdd) {
		SetLives(m_livesRemaining + numToAdd);
	}

	private void SetScore(int score) {
		m_score = score;
		SendMessage("ScoreUpdated", m_score, SendMessageOptions.DontRequireReceiver);
	}
	
	private void AddScore(int numToAdd) {
		SetScore(m_score + numToAdd);
	}
}
