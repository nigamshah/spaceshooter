using UnityEngine;
using System.Collections;

public class HeroManager : MonoBehaviour {

	private const string SPAWN_POINT_TAG = "HeroSpawnPoint";

	public GameObject HeroTemplate;
	public int LivesRemaining = 3;
	public float SpawnDelay = 0.5f;


	// Use this for initialization
	void Awake() {
	
	}

	private void SpawnHero() {
		print("HeroManager.SpawnHero");
		return;
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
		if (craft.name == "Hero") {
			LivesRemaining--;
			if (LivesRemaining == 0) {
				SendMessage("GameOver");
			} else {
				Invoke("SpawnHero", SpawnDelay);
			}
		}
	}
}
