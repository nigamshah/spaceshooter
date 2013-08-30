using UnityEngine;
using System;
using System.Collections;

public class Config : MonoBehaviour {

	private Hashtable m_config;

	public ArrayList WaveNames {
		get {
			return m_config["waves"] as ArrayList;
		}
	}
	public int MaxLevel {
		get { return WaveNames.Count - 1; }
	}

	public float LevelDelay {
		get {
			float result = m_config.ContainsKey("levelDelay") ? (float) m_config["levelDelay"] : 1.0f;
			return result;
		}
	}

	public int StartingLives {
		get {
			int result = m_config.ContainsKey("startingLives") ? Convert.ToInt32(m_config["startingLives"]) : 3;
			return result;
		}
	}

	public Hashtable LevelBonuses {
		get {
			Hashtable result = m_config["levelBonuses"] as Hashtable;
			return result;
		}
	}

	public Hashtable ScoreTable {
		get {
			Hashtable result = m_config["scoreTable"] as Hashtable;
			return result;
		}
	}
	public ArrayList ScoreMultipliers {
		get {
			ArrayList result = m_config["scoreMultipliers"] as ArrayList;
			return result;
		}
	}

	// Use this for initialization
	void Awake() {
		TextAsset configAsset = (TextAsset)Resources.Load("Config/config");
		m_config = MiniJSON.jsonDecode(configAsset.text) as Hashtable;
	}
}
