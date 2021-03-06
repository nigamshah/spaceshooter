﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {

	private const string ENEMY_WAVE_PATH = "Prefabs/EnemyWaves/";
	private const string SPAWN_POINT_TAG = "EnemySpawnPoint";
	
	private string[][] m_waveNames;
	private LevelManager m_levelManager;
	private int m_currentWave = 0;

	// Use this for initialization

	void Awake() {
		m_levelManager = GetComponent<LevelManager>();
	}
	void Start() {
		Config config = GetComponent<Config>();

		int l = config.WaveNames.Count;
		m_waveNames = new string[l][];
		for (int i = 0; i < l; i++) {
			m_waveNames[i] = (string[]) ((ArrayList)config.WaveNames[i]).ToArray(typeof(string));
		}
	}

	private void ResetGame() {
		m_currentWave = 0;
	}

	private string GetNextWaveName() {
		string result = m_waveNames[m_levelManager.CurrentLevel][m_currentWave];
		return result;
	}

	public void SpawnNextWave() {
		CancelInvoke("SpawnNextWave");
		//print("Spawning Wave " + m_levelManager.CurrentLevel + "." + m_currentWave);
		string waveName = GetNextWaveName();

		// there must be at least 1
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(SPAWN_POINT_TAG);
		if (spawnPoints.Length == 0) {
			Debug.LogError("There must be at least one EnemySpawnPoint in the scene");
			return;
		}

		int spawnIndex = RandomGenerator.Random.Next(spawnPoints.Length);
		Vector3 position = spawnPoints[spawnIndex].transform.position;
		Quaternion rotation = spawnPoints[spawnIndex].transform.rotation; //  should be Quaternion.identity (aka "no rotation"), but just in case

		GameObject wave = (GameObject) Instantiate(Resources.Load(ENEMY_WAVE_PATH + waveName, typeof(GameObject)), position, rotation);
		wave.transform.parent = transform;

		BroadcastMessage("ResetAmmo", SendMessageOptions.DontRequireReceiver);
	}

	private void WaveCompleted(bool destroyed) {
		m_currentWave++;
		if (m_currentWave == m_waveNames[m_levelManager.CurrentLevel].Length) {
			m_currentWave = 0;
			SendMessage("LevelCompleted", SendMessageOptions.DontRequireReceiver);
		} else {
			SendMessage("DestroyAllEnemies", SendMessageOptions.DontRequireReceiver);
			string msg = destroyed ? "WAVE DESTROYED - NICE!" : "WAVE PASSED";
			SendMessage("DoCallout", msg, SendMessageOptions.DontRequireReceiver);
			Invoke("SpawnNextWave", 5.0f);
		}
	}
}
