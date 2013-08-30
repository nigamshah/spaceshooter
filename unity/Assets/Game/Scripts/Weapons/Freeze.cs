using UnityEngine;
using System.Collections;

public class Freeze : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		print("FREEZE !!!");
		Spacecraft craft = collision.gameObject.GetComponent<Spacecraft>();
		if (craft) {
			craft.BroadcastMessage("DisableMovement", SendMessageOptions.DontRequireReceiver);
			craft.Invoke("EnableMovement", 4.0f);
		}

	}
}
