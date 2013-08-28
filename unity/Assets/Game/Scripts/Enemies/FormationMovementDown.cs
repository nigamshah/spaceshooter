using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Formation))]
public class FormationMovementDown : MonoBehaviour {

	public float DropInterval = 1f; // Main Camera world units/second

	private Formation m_formation;

	// Use this for initialization
	void Start () {
		m_formation = GetComponent<Formation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_formation.IsAtEdge()) {
			transform.Translate(new Vector3(0f, -1 * DropInterval));
		}

		if (transform.position.y <= Formation.MIN_Y) {
			SendMessage("FormationAtBottom");
		}
	}
}
