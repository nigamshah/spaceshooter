using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Config))]
public class LevelManager : MonoBehaviour {

	private int m_maxLevel;
	private float m_levelDelay;
	private Hashtable m_levelBonuses;


	private int m_currentLevel = 0;
	public int CurrentLevel {
		get { return m_currentLevel; }
	}


	// Use this for initialization
	void Start () {
		Config config = GetComponent<Config>();
		m_maxLevel = config.MaxLevel;
		m_levelDelay = config.LevelDelay;
		m_levelBonuses = config.LevelBonuses;
	}

	private void LevelCompleted() {
		print("level " + m_currentLevel + " completed");
		m_currentLevel++;
		ApplyLevelBonuses();
		if (m_currentLevel > m_maxLevel) {
			SendMessage("GameWon", SendMessageOptions.DontRequireReceiver);
		} else {
			Invoke("StartNextLevel", m_levelDelay);
		}
	}

	private void ApplyLevelBonuses() {

	}

	private void StartNextLevel() {
		SendMessage("SpawnNextWave", SendMessageOptions.DontRequireReceiver);
	}


}
