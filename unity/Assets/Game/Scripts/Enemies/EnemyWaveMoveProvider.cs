using UnityEngine;
using System.Collections;

public class EnemyWaveMoveProvider : MonoBehaviour {
	private const float MIN_X = -9.5f;
	private const float MAX_X = 9.5f;
	
	// public vars -- can be changed in Inspector	
	public float InitialSpeed = 5f; // Main Camera world units/second
	public float DropInterval = 1f; // Main Camera world units/second
	
	// TODO: Change back to private
	// -- only public for playtesting in the Inspector
	public float m_currentSpeed = 0;

	private float m_hAxisValue;

	// Use this for initialization
	void Start () {
		ResetSpeed();
		m_hAxisValue = 1;
	}

	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;

		if (currentPosition.x == MIN_X || currentPosition.x == MAX_X) {
			currentPosition.y -= DropInterval;
			m_hAxisValue *= -1;
		}

		float translation = m_hAxisValue * m_currentSpeed * Time.deltaTime;
		currentPosition.x += translation;
		currentPosition.x = Mathf.Clamp(currentPosition.x, MIN_X, MAX_X);

		transform.position = currentPosition;
	}
	
	void ResetSpeed() {
		m_currentSpeed = InitialSpeed;
	}
	void SetSpeed(float speed) {
		m_currentSpeed = speed;
	}
	
	void DisableMovement() {
		this.enabled = false;
	}
	void EnableMovement() {
		this.enabled = true;
	}
}
