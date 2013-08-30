using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Formation : MonoBehaviour {

	public const float MIN_X = -9.5f;
	public const float MAX_X = 9.5f;
	public const float MIN_Y = -7.5f;
	public const float MAX_Y = 7.5F;
	
	private List<GameObject> m_enemies;
	private List<GameObject> m_enemiesToIgnore;

	private Transform m_left;
	private Transform m_right;
	private Transform m_bottom;
	private Transform m_top;	// not used right now, but could be useful later

	public Transform Top {
		get { return m_top; }
	}
	public Transform Bottom {
		get { return m_bottom; }
	}

	public Transform Left {
		get { return m_left; }
	}
	public Transform Right {
		get { return m_right; }
	}

	// Use this for initialization
	void Start () {
		m_enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
		m_enemiesToIgnore = new List<GameObject>();
		ResetFormation();
		BroadcastMessage("FormationSet", SendMessageOptions.DontRequireReceiver);
	}

	private void SpacecraftDestroyed(GameObject enemy) {
		Transform trans = enemy.transform;
		m_enemies.Remove(enemy);

		if (m_enemies.Count == 0) {
			FormationDestroyed();
		} else if (trans == m_left || trans == m_right || trans == m_bottom) {
			ResetFormation();
		}
	}

	private void SpacecraftAdded(GameObject enemy) {
		m_enemiesToIgnore.Remove(enemy);
		ResetFormation();
	}
	private void SpacecraftRemoved(GameObject enemy) {
		m_enemiesToIgnore.Add(enemy);
		ResetFormation();
	}

	private void ResetFormation() {
		m_top = null;
		m_bottom = null;
		m_left = null;
		m_right = null;

		for (int i = 0; i < m_enemies.Count; i++) {
			if (m_enemiesToIgnore.Contains(m_enemies[i])) continue;

			Transform trans = m_enemies[i].transform;
			if (m_top == null || trans.position.y > m_top.position.y) {
				m_top = trans;
			}
			if (m_bottom == null || trans.position.y < m_bottom.position.y) {
				m_bottom = trans;
			}

			if (m_left == null || trans.position.x < m_left.position.x) {
				m_left = trans;
			}
			if (m_right == null || trans.position.x > m_right.position.x) {
				m_right = trans;
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Top != null && Top.position.y <= MIN_Y) {
			FormationPassed();
		}
	}

	private void FormationPassed() {
		SendMessageUpwards("WaveCompleted", false, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
	private void FormationDestroyed() {
		SendMessageUpwards("WaveCompleted", true, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}

	public bool IsAtEdge() {
		bool result = ((Left != null && Left.position.x <= MIN_X) || (Right != null && Right.position.x >= MAX_X));
		return result;
	}

}
