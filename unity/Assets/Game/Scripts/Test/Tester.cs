﻿using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	void Awake() {
		print("Tester.Awake()");
	}
	
	
	// Use this for initialization
	void Start () {
		print("Tester.Start()");

		// get it started
		SendMessage("SpawnNextWave");

	}
	
	// Update is called once per frame
	void Update () {
	}
}