using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FireDirection))]
public class AutoFireRandom : MonoBehaviour {

	public FireControl FireControl;
	public float RollInterval = 1.0f;

	[Range(0, 100)]
	public int Probability = 50; // 0 - 100

	private FireDirection m_fireDirection;
	private string m_fireControlString;

	private bool m_fireAway;
	
	// Use this for initialization
	void Awake() {
		m_fireDirection = GetComponent<FireDirection>();
		m_fireControlString = FireControl.ToString();
	}

	// Use this for initialization
	void Start () {
		FireAway();
	}

	private void FireAway() {
		if (!IsInvoking("TryFire")) {
			InvokeRepeating("TryFire", RollInterval, RollInterval);
		}
	}
	private void CeaseFire() {
		CancelInvoke("TryFire");
	}

	private void TryFire() {
		bool shouldFire = ShouldFire();
		if (shouldFire) {
			FireCommand command = new FireCommand();
			command.Direction = m_fireDirection.CurrentDirection;
			command.FireControlString = m_fireControlString;
			SendMessage("FireWeapon", command, SendMessageOptions.DontRequireReceiver);
		}
	}

	bool ShouldFire() {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
			bool hitEnemy = hit.collider.CompareTag("Enemy");
			if (hitEnemy) return false;
		}

		int roll = RandomGenerator.Random.Next(100);
		bool result = roll < Probability;
		return result;
	}

	void OnDestroy() {
		CancelInvoke();
	}
}
