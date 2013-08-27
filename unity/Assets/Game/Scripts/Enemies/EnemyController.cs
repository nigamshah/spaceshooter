using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject SpawnEffect;
	public GameObject KillEffect;

	// Use this for initialization
	void Start() {
		if (SpawnEffect != null) {
			// instantiate spawn effect
		}
	
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	void DirectHit() {
		// this happens after the armor has failed
		Die();
	}

	void Die() {
		if (KillEffect != null) {
			Instantiate(KillEffect, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}
