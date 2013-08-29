using UnityEngine;
using System.Collections;

public class SpacecraftController : MonoBehaviour {

	public GameObject SpawnEffect;
	public GameObject KillEffect;

	private bool m_hasArmor = false;

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

	private void EnableArmor() {
		m_hasArmor = true;
	}

	private void ArmorFailed() {
		print("ArmorFailed !!!!!");
		m_hasArmor = false;
	}

	void OnCollisionEnter(Collision collision) {

		bool enemyToPlayer = 
			(collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player")) ||
			(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"));
		// ^^ NOTE: I do not want a Direct Hit if it is an Enemy-To-Enemy collision


		if (!m_hasArmor || enemyToPlayer) {
			DirectHit();
		}
	}


	private void DirectHit() {
		SendMessageUpwards("SpacecraftDestroyed", gameObject, SendMessageOptions.DontRequireReceiver);
		if (KillEffect != null) {
			Instantiate(KillEffect, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}