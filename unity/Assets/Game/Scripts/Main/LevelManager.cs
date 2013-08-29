using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private int m_currentLevel = 0;
	public int CurrentLevel {
		get { return m_currentLevel; }
	}


	// Use this for initialization
	void Awake() {
	}

	void Start () {
	
	}

	private void LevelCompleted() {
		m_currentLevel++;
		print("level completed, level = " + m_currentLevel);
	}


}
