using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		Spacecraft craft = collision.gameObject.GetComponent<Spacecraft>();
		if (craft) {
			craft.StopMoving();
			craft.Invoke("StartMoving", 4.0f);
		}

	}
}
