using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	private const string SPAWN_POINT_TAG = "HeroSpawnPoint";

	public GameObject HeroTemplate;
	public float SpawnDelay = 0.5f;

	private int m_livesRemaining = 0;

	// Use this for initialization
	void Start() {
		SetLives(GetComponent<Config>().StartingLives);
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
		if (craft.CompareTag("Player")) {
			AddLives(-1);
			if (m_livesRemaining == 0) {
				SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
			} else {
				Invoke("SpawnHero", SpawnDelay);
			}
		}
	}

	private void SetLives(int lives) {
		m_livesRemaining = lives;
		SendMessage("LivesUpdated", m_livesRemaining, SendMessageOptions.DontRequireReceiver);
	}

	private void AddLives(int numToAdd) {
		SetLives(m_livesRemaining + numToAdd);
	}
}
