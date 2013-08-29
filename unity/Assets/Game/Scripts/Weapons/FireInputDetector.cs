using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FireInputDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update() {

		foreach(string fireAxisString in Enum.GetNames(typeof(FireAxis))) {
			float fireAxisValue = Input.GetAxis(fireAxisString);
			if (fireAxisValue != 0) {
				SendMessage("FireWeapon", fireAxisString, SendMessageOptions.DontRequireReceiver);
				break;
			}
		}

	}

}
