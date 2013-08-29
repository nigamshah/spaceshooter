using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	void Awake() {
		print("Tester.Awake()");
	}
	
	
	// Use this for initialization
	void Start () {
		print("Tester.Start()");

		// get it started

		Invoke("SpawnHero", 0.5f);
		Invoke("SpawnFirstWave", 1.0f);
	}

	void SpawnHero() {
		print("SpawnHero delayed");
		//SendMessage("SpawnHero", SendMessageOptions.DontRequireReceiver);
	}
	void SpawnFirstWave() {
		print("SpawnFirstWave delayed");
		//SendMessage("SpawnNextWave");
	}
	
	// Update is called once per frame
	void Update () {
	}
}