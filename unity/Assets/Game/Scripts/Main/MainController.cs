using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

	void Awake() {
		print("MainController.Awake()");
	}
	
	
	// Use this for initialization
	void Start () {
		print("MainController.Start()");
		StartGame();
	}

	private void StartGame() {
		// get it started
		BroadcastMessage("ResetGame");
		Invoke("SpawnFirstHero", 1f);
		Invoke("SpawnFirstWave", 3.0f);
	}

	private void SpawnFirstHero() {
		SendMessage("SpawnHero", SendMessageOptions.DontRequireReceiver);
	}
	private void SpawnFirstWave() {
		SendMessage("SpawnNextWave", SendMessageOptions.DontRequireReceiver);
	}

	//------------------------------
	// in the interest of time,
	// just going to display a message and restart the game
	//------------------------------
	private void GameOver() {
		print("GameOver");
		DestroySpacecraft();
		SendMessage("DoCallout", "GAME OVER - STARTING OVER", SendMessageOptions.DontRequireReceiver);
		Invoke("StartGame", 6.0f);
	}
	private void GameWon() {
		print("GameWon");
		DestroySpacecraft();
		SendMessage("DoCallout", "YOU WIN !!! - STARTING OVER", SendMessageOptions.DontRequireReceiver);
		Invoke("StartGame", 6.0f);
	}

	private void DestroySpacecraft() {
		GameObject[] waves = GameObject.FindGameObjectsWithTag("EnemyWave");
		foreach(GameObject wave in waves) {
			Destroy(wave);
		}
		
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null) {
			Destroy(player);
		}
	}
}