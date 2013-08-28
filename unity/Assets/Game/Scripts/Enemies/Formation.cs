using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Formation : MonoBehaviour {

	public const float MIN_X = -9.5f;
	public const float MAX_X = 9.5f;
	public const float MIN_Y = -5.5f;

	
	private List<GameObject> m_enemies;

	private Transform m_left;
	private Transform m_right;
	private Transform m_bottom;
	private Transform m_top;	// not used for now

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
		Reset();
	}

	private void EnemyDestroyed(GameObject enemy) {
		print("EnemyDestroyed - name = " + enemy.name);
		Transform trans = enemy.transform;
		m_enemies.Remove(enemy);

		if (m_enemies.Count == 0) {
			FormationDestroyed();
		} else if (trans == m_left || trans == m_right || trans == m_bottom) {
			Reset();
		}
	}

	private void Reset() {
		m_top = m_enemies[0].transform;
		m_bottom = m_enemies[0].transform;
		m_left = m_enemies[0].transform;
		m_right = m_enemies[0].transform;

		for (int i = 1; i < m_enemies.Count; i++) {
			Transform trans = m_enemies[i].transform;
			if (trans.position.y > m_top.position.y) {
				m_top = trans;
			}
			if (trans.position.y < m_bottom.position.y) {
				m_bottom = trans;
			}

			if (trans.position.x < m_left.position.x) {
				m_left = trans;
			}
			if (trans.position.x > m_right.position.x) {
				m_right = trans;
			}
		}
	}

	private void FormationAtBottom() {
		print("Formation Landed");

	}
	private void FormationDestroyed() {
		print("destroying formation game object");
		Destroy(gameObject);
	}

	public bool IsAtEdge() {
		bool result = (Left.position.x <= Formation.MIN_X || Right.position.x >= Formation.MAX_X);
		return result;
	}
}
