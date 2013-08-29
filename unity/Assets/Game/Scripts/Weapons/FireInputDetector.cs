using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(FireDirection))]
public class FireInputDetector : MonoBehaviour {

	private FireDirection m_fireDirection;

	// Use this for initialization
	void Awake() {
		m_fireDirection = GetComponent<FireDirection>();
	}
	
	// Update is called once per frame
	void Update() {

		foreach(string fireControlString in Enum.GetNames(typeof(FireControl))) {
			float fireAxisValue = Input.GetAxis(fireControlString);
			if (fireAxisValue != 0) {
				FireCommand command = new FireCommand();
				command.Direction = m_fireDirection.CurrentDirection;
				command.FireControlString = fireControlString;
				SendMessage("FireWeapon", command, SendMessageOptions.DontRequireReceiver);
				break; // break because you cannot fire 2 weapons at the same time
			}
		}

	}

}
