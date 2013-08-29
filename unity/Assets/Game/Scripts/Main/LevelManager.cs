using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private Config m_config;
	private int m_currentLevel = 0;
	public int CurrentLevel {
		get { return m_currentLevel; }
	}


	// Use this for initialization
	void Awake() {
		m_config = GetComponent<Config>();
	}

	void Start () {
	
	}

	private void LevelCompleted() {
		print("level completed, level = " + m_currentLevel);
		m_currentLevel++;
		if (m_currentLevel > m_config.MaxLevel) {
			SendMessage("GameWon", SendMessageOptions.DontRequireReceiver);
		} else {
			print("level Delay = " + m_config.LevelDelay);
			Invoke("StartNextLevel", m_config.LevelDelay);
		}
	}

	private void StartNextLevel() {
		SendMessage("SpawnNextWave", SendMessageOptions.DontRequireReceiver);
	}


}
