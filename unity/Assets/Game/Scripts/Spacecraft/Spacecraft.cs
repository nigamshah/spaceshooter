using UnityEngine;
using System.Collections;

public class Spacecraft : MonoBehaviour {

	public SpacecraftType SpacecraftType;

	public GameObject SpawnEffect;
	public GameObject KillEffect;

	private bool m_hasArmor = false;
	private Transform m_initialParent;

	// Use this for initialization
	void Start() {
		if (SpawnEffect != null) {
			// instantiate spawn effect
			renderer.enabled = false;
			Instantiate(SpawnEffect, transform.position, transform.rotation);
			Invoke("Show", 0.25f);
		}
		m_initialParent = transform.parent;
	}

	private void Show() {
		renderer.enabled = true;
	}

	private void EnableArmor() {
		m_hasArmor = true;
	}

	private void ArmorFailed() {
		m_hasArmor = false;
	}

	private void DisableMovement() {
		SendMessageUpwards("SpacecraftRemoved", gameObject, SendMessageOptions.DontRequireReceiver);
		transform.parent = null;
	}
	private void EnableMovement() {
		transform.parent = m_initialParent;
		SendMessageUpwards("SpacecraftAdded", gameObject, SendMessageOptions.DontRequireReceiver);
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
		transform.parent = m_initialParent;
		SendMessageUpwards("SpacecraftDestroyed", gameObject, SendMessageOptions.DontRequireReceiver);
		if (KillEffect != null) {
			Instantiate(KillEffect, transform.position, transform.rotation);
		}
		Destroy(gameObject);
	}
}