using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	private const string ENEMY_WAVE_PATH = "Prefabs/Enemies/";
	private const string ENEMY_SPAWN_POINT_TAG = "EnemySpawnPoint";

	private int m_currentWave = 0;
	private string[][] m_waves;

	private LevelManager m_levelManager;

	void Awake() {
		m_waves = new string[2][];
		m_waves[0] = new string[] {"EnemyWave_1.1", "EnemyWave_1.2", "EnemyWave_1.3"};
		m_waves[1] = new string[] {"EnemyWave_1.2", "EnemyWave_1.3"};

	}

	// Use this for initialization
	void Start () {
		m_levelManager = GetComponent<LevelManager>();
	}

	private string GetNextWaveName() {
		// for now, we will just continue to repeat the last level & wave ad infinitum
		int levelIndex = Mathf.Clamp(m_levelManager.CurrentLevel, 0, m_waves.Length - 1);
		int waveIndex = Mathf.Clamp(m_currentWave, 0, m_waves[levelIndex].Length - 1);

		string result = m_waves[levelIndex][waveIndex];
		return result;
	}


	private void SpawnNextWave() {
		string waveName = GetNextWaveName();

		// there must be at least 1
		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(ENEMY_SPAWN_POINT_TAG);
		if (spawnPoints.Length == 0) {
			Debug.LogError("There must be at least one EnemySpawnPoint in the scene");
			return;
		}

		int spawnIndex = RandomGenerator.Random.Next(spawnPoints.Length);
		Vector3 position = spawnPoints[spawnIndex].transform.position;
		Quaternion rotation = spawnPoints[spawnIndex].transform.rotation; //  should be Quaternion.identity (aka "no rotation"), but just in case

		GameObject wave = (GameObject) Instantiate(Resources.Load(ENEMY_WAVE_PATH + waveName, typeof(GameObject)), position, rotation);
		wave.transform.parent = transform;
	}

	private void WaveCompleted() {
		m_currentWave++;

		print("Wave complete - next wave = " + m_currentWave);

		// for now, we will just continue to repeat the last level & wave ad infinitum
		int levelIndex = Mathf.Clamp(m_levelManager.CurrentLevel, 0, m_waves.Length - 1);
		print("levelIndex = " + levelIndex);

		if (m_currentWave >= m_waves[levelIndex].Length) {
			m_currentWave = 0;
			SendMessage("LevelCompleted", SendMessageOptions.DontRequireReceiver);
		} else {
			Invoke("SpawnNextWave", 1.0f);
		}
	}
}
