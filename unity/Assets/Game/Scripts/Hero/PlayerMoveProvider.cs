using UnityEngine;
using System.Collections;

public class PlayerMoveProvider : MonoBehaviour {

	private const float MIN_X = -9.5f;
	private const float MAX_X = 9.5f;

	// public vars -- can be changed in Inspector	
	public float InitialSpeed = 25f; // Main Camera world units/second

	// TODO: Change back to private
	// -- only public for playtesting in the Inspector
	public float m_currentSpeed = 0;

	// Use this for initialization
	void Start () {
		ResetSpeed();
	}
	
	// Update is called once per frame
	void Update () {
		float hAxisValue = Input.GetAxis("Horizontal");

		if (hAxisValue != 0) {
			float translation = hAxisValue * m_currentSpeed * Time.deltaTime;
			Vector3 currentPosition = transform.position;
			currentPosition.x += translation;
			currentPosition.x = Mathf.Clamp(currentPosition.x, MIN_X, MAX_X);
			transform.position = currentPosition;
		}
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