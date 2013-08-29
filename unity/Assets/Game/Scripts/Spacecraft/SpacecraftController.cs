using UnityEngine;
using System.Collections;

public class SpacecraftController : MonoBehaviour {

	public GameObject SpawnEffect;
	public GameObject KillEffect;

	// Use this for initialization
	void Start() {
		if (SpawnEffect != null) {
			// instantiate spawn effect
			renderer.enabled = false;
			Instantiate(SpawnEffect, transform.position, transform.rotation);
			Invoke("Show", 0.25f);
		}
	}

	private void Show() {
		renderer.enabled = true;
	}

	void DirectHit() {
		// this happens after the armor has failed
		Die();
	}

	void Die() {
		SendMessageUpwards("SpacecraftDestroyed", gameObject, SendMessageOptions.DontRequireReceiver);
		if (KillEffect != null) {
			Instantiate(KillEffect, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}
