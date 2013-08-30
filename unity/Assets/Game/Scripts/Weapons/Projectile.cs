using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public GameObject MuzzleFire;
	public GameObject Explosion;

	// default values -- different for each type of projectile
	public float Damage = 1.0f;

	// Use this for initialization
	void Start () {
		transform.parent = null; // detaches immediately
		if (MuzzleFire != null) {
			Instantiate(MuzzleFire, transform.position, transform.rotation);
		}
	}

	void OnCollisionEnter() {
		if (Explosion != null) {
			Instantiate(Explosion, transform.position, transform.rotation);
		}

		Destroy(gameObject);
	}

}
