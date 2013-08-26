using UnityEngine;
using System.Collections;

public class PlayerMoveProvider : MonoBehaviour {

	// public vars -- can be changed in Inspector

	// expressed in pixels per second
	public float InitialSpeed = 900f;

	private float m_currentSpeed = 0;

	// Use this for initialization
	void Start () {
		ResetSpeed();
	}
	
	// Update is called once per frame
	void Update () {
		float hAxisValue = Input.GetAxis("Horizontal");
		//print("hAxisValue = " + hAxisValue);
		
		if (hAxisValue != 0) {
			Move(hAxisValue);
		}
	}

	void Move(float axisValue) {
		float translation = axisValue * m_currentSpeed * Time.deltaTime;
		transform.Translate(translation, 0, 0);
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
