using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Formation))]
public class FormationMovementHorizontal : MonoBehaviour {

	// public vars -- can be changed in Inspector	
	public float InitialSpeed = 5f; // Main Camera world units/second
	public float SpeedIncrement = 0.5f;
	public float MaxSpeed = 10f;

	// TODO: Change back to private
	// -- only public for playtesting in the Inspector
	public float m_currentSpeed = 0;

	private int m_direction = 0;

	private Formation m_formation;

	// Use this for initialization
	void Awake() {
		this.enabled = false;
	}
	
	// Use this for initialization
	void Start () {
		ResetSpeed();
		m_direction = 1;
		m_formation = GetComponent<Formation>();
	}

	private void FormationSet() {
		this.enabled = true;
	}

	// Update is called once per frame
	void Update () {

		// if at either edge change direction
		if (m_formation.IsAtEdge()) {
			m_direction *= -1;
			SetSpeed(m_currentSpeed + SpeedIncrement);
		}

		// do the horizontal translation
		Vector3 currentPosition = transform.position;

		float translation = m_direction * m_currentSpeed * Time.deltaTime;
		currentPosition.x += translation;
		transform.position = currentPosition;
	}
	
	private void ResetSpeed() {
		SetSpeed(InitialSpeed);
	}
	private void SetSpeed(float speed) {
		m_currentSpeed = Mathf.Max(speed, MaxSpeed);
	}
	
	private void DisableMovement() {
		this.enabled = false;
	}
	private void EnableMovement() {
		this.enabled = true;
	}
}
