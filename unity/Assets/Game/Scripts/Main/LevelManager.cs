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

	private void ResetGame() {
		CancelInvoke();
		//print("Level Mananger ResetGame");
		m_currentLevel = 0;
	}

	private void LevelCompleted() {
		m_currentLevel++;
		ApplyLevelBonuses();
		if (m_currentLevel > m_maxLevel) {
			SendMessage("GameWon", SendMessageOptions.DontRequireReceiver);
		} else {
			SendMessage("DoCallout", "LEVEL COMPLETE, GOOD JOB!", SendMessageOptions.DontRequireReceiver);
			SendMessage("DestroyAllEnemies", SendMessageOptions.DontRequireReceiver);
			print("LEVEL COMPLETE, " + m_currentLevel);
			Invoke("StartNextLevel", m_levelDelay);
		}
	}

	private void ApplyLevelBonuses() {
		// TODO: Level Bonuses
	}

	private void StartNextLevel() {
		print("StartNextLevel");
		GetComponent<WaveManager>().SpawnNextWave();
	}


}
