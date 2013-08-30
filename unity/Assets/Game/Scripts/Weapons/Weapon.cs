using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	// public vars can be edited in Inspector

	public GameObject Projectile;
	public FireControl FireControl;
	public float ImpulseForce = 10.0f;
	public float Cooldown = 0.1f;
	public int StartingAmmo = -1;
	public float ShootingPointOffsetY = 0f;

	private string m_fireControlString;
	private Quaternion m_rotation;
	private Vector3 m_shootingPointOffset;
	private bool m_inCooldown;
	private int m_currentAmmo;


	// Use this for initialization
	void Start() {
		// 0.05 seconds is the minimum cooldown, otherwise the bullets hit themselves
		Cooldown = Mathf.Max(0.05f, Cooldown);

		m_fireControlString = FireControl.ToString();
		m_rotation = transform.rotation;

		// may need to become configurable
		m_shootingPointOffset = new Vector3(0, ShootingPointOffsetY, 0);
		m_inCooldown = false;

		ResetAmmo();
	}

	private void FireWeapon(FireCommand command) {

		if (!m_inCooldown && m_currentAmmo != 0 && command.FireControlString == m_fireControlString) {
			Vector3 pos = transform.position + m_shootingPointOffset;
			GameObject projectile = Instantiate(Projectile, pos, m_rotation) as GameObject;
			projectile.rigidbody.AddForce(command.Direction * ImpulseForce, ForceMode.Impulse);
			m_inCooldown = true;
			if (m_currentAmmo > 0) m_currentAmmo--;
			Invoke("ResetCooldown", Cooldown);
		}
	}
	private void ResetCooldown() {
		m_inCooldown = false;
	}
	private void ResetAmmo() {
		m_currentAmmo = StartingAmmo;
	}

	void OnDestroy() {
		CancelInvoke();
	}
}

public struct FireCommand {
	public Vector3 Direction;
	public string FireControlString;
}
