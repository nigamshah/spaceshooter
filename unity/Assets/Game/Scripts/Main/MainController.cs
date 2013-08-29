using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

	void Awake() {
		print("MainController.Awake()");
	}
	
	
	// Use this for initialization
	void Start () {
		print("MainController.Start()");

		// get it started

		Invoke("SpawnFirstHero", 1f);
		Invoke("SpawnFirstWave", 3.0f);
	}

	private void SpawnFirstHero() {
		SendMessage("SpawnHero", SendMessageOptions.DontRequireReceiver);
	}
	private void SpawnFirstWave() {
		SendMessage("SpawnNextWave", SendMessageOptions.DontRequireReceiver);
	}

	private void GameOver() {
		print("GameOver");
	}
	private void GameWon() {
		print("GameWon");
	}
}