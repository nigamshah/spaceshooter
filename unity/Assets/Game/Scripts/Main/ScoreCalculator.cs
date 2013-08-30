using UnityEngine;
using System.Collections;

public class ScoreCalculator : MonoBehaviour {

	private Hashtable m_scoreTable;
	private ArrayList m_scoreMultipliers;
	private LevelManager m_levelManager;

	// Use this for initialization
	void Start () {
		Config config = GetComponent<Config>();
		m_levelManager = GetComponent<LevelManager>();
		m_scoreTable = config.ScoreTable;
		m_scoreMultipliers = config.ScoreMultipliers;
	}

	public int GetScore(string key) {
		int result = 0;
		if (m_scoreTable.ContainsKey(key)) {
			float baseScore = (float) m_scoreTable[key];
			float multiplier = (float) m_scoreMultipliers[m_levelManager.CurrentLevel];
			result = Mathf.CeilToInt(baseScore * multiplier);
		}
		return result;
	}
}
