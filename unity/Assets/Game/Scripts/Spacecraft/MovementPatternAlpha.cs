using UnityEngine;
using System;
using System.Collections;

// this is a simple Movement Pattern, within a range

public class MovementPatternAlpha : MonoBehaviour {

	private const float SPEED = 0.05f;
	private const float RANGE = 1f;


	private Vector3 m_startingPoint;
	private Vector3 m_direction;

	// Use this for initialization
	void Awake() {
		this.enabled = false;
	}
	
	// Use this for initialization
	void Start() {
		m_startingPoint = transform.localPosition;
		// choose a starting direction
		ResetDirection();
	}
	
	private void FormationSet() {
		this.enabled = true;
	}

	private void ResetDirection() {
		m_startingPoint = transform.localPosition;

		System.Random rand = RandomGenerator.Random;

		float x = (float) rand.NextDouble() * (rand.Next(2) == 1 ? 1 : -1);
		float y = (float) rand.NextDouble() * (rand.Next(2) == 1 ? 1 : -1);


		m_direction = new Vector3(x, y, 0);
		//print("ResetDirection - " + name + " / " + m_direction);
	}

	// Update is called once per frame
	void Update() {

		//transform.Translate(m_direction * SPEED * Time.deltaTime);
		transform.Translate(m_direction * SPEED);

		float distance = Vector3.Distance(m_startingPoint, transform.localPosition);
		if (distance >= RANGE) {
			ResetDirection();
		}

		// Clamp the position to the formation, and reset the direction in those cases
		if (transform.position.x < Formation.MIN_X) {
			transform.position = new Vector3(Formation.MIN_X, transform.position.y);
			ResetDirection();
		} else if (transform.position.x > Formation.MAX_X) {
			transform.position = new Vector3(Formation.MAX_X, transform.position.y);
			ResetDirection();
		}

		if (transform.position.y < Formation.MIN_Y) {
			transform.position = new Vector3(transform.position.x, Formation.MIN_Y);
			ResetDirection();
		} else if (transform.position.y > Formation.MAX_Y) {
			transform.position = new Vector3(transform.position.x, Formation.MAX_Y);
			ResetDirection();
		}

	}

}
