using UnityEngine;
using System.Collections;

public class Config : MonoBehaviour {


	private ArrayList m_waveNames;
	public ArrayList WaveNames {
		get { return m_waveNames; }
	}
	public int MaxLevel {
		get { return m_waveNames.Count - 1; }
	}

	private float m_levelDelay = 1.0f; // default value
	public float LevelDelay {
		get { return m_levelDelay; }
	}

	// Use this for initialization
	void Awake() {
		TextAsset configAsset = (TextAsset)Resources.Load("Config/config");
		Hashtable config = MiniJSON.jsonDecode(configAsset.text) as Hashtable;

		// init waves
		m_waveNames = (ArrayList) config["waves"];// as ArrayList;
		if (m_waveNames.Count < 1 || ((ArrayList)m_waveNames[0]).Count < 1) {
			Debug.LogError("There must be at least one wave.");
		}

		if (config.ContainsKey("levelDelay")) {
			m_levelDelay = (float) config["levelDelay"];
		}
	}
}
