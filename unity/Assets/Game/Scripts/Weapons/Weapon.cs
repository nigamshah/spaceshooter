using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	// public vars can be edited in Inspector

	public GameObject Projectile;
	public FireAxis InputAxis;
	public float ImpulseForce = 10.0f;
	public float Cooldown = 0.1f;

	private string m_inputAxisString;
	private Quaternion m_rotation;
	private Vector3 m_shootingPointOffset;
	private bool m_inCooldown;

	// Use this for initialization
	void Start() {
		// 0.05 seconds is the minimum cooldown, otherwise the bullets hit themselves
		Cooldown = Mathf.Max(0.05f, Cooldown);

		m_inputAxisString = InputAxis.ToString();
		m_rotation = transform.rotation;

		// may need to become configurable
		m_shootingPointOffset = new Vector3(0, 1.1f, 0);
		m_inCooldown = false;
	}

	private void FireWeapon(string fireAxisString) {
		if (!m_inCooldown && fireAxisString == m_inputAxisString) {
			Vector3 pos = transform.position + m_shootingPointOffset;
			GameObject projectile = Instantiate(Projectile, pos, m_rotation) as GameObject;
			projectile.rigidbody.AddForce(transform.up * ImpulseForce, ForceMode.Impulse);
			m_inCooldown = true;
			Invoke("ResetCooldown", Cooldown);
		}
	}
	private void ResetCooldown() {
		m_inCooldown = false;
	}

}
