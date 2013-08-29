using UnityEngine;
using System.Collections;

public class FireDirection : MonoBehaviour {

	public Direction InitialDirection;

	private Vector3 m_currentDirection;
	public Vector3 CurrentDirection {
		get { return m_currentDirection; }
	}

	void Awake() {
		m_currentDirection = InitialDirection.ToVector3();
	}

}
