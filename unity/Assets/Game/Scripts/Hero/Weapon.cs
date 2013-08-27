using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public enum FireAxis {
		Fire1, Fire2, Fire3
	}

	// public vars can be edited in Inspector

	public GameObject Projectile;
	public FireAxis InputAxis;
	public float Cooldown = 0.1f;
	
	private string m_inputAxisString;
	private Quaternion m_rotation;
	private Vector3 m_shootingPointOffset;


	// Use this for initialization
	void Start() {

		// 0.05 seconds is the minimum cooldown, otherwise the bullets hit themselves
		Cooldown = Mathf.Max(0.05f, Cooldown);
		m_inputAxisString = InputAxis.ToString();
		m_rotation = transform.rotation;

		m_shootingPointOffset = new Vector3(0, 1.1f, 0);
	}
	
	// Update is called once per frame
	void Update() {
		float fireAxisValue = Input.GetAxis(m_inputAxisString);
		if (fireAxisValue != 0) {
			Vector3 pos = transform.position + m_shootingPointOffset;
			GameObject bullet = Instantiate(Projectile, pos, m_rotation) as GameObject;
			this.enabled = false;
			Invoke("ResetCooldown", Cooldown);
		}
	}
	private void ResetCooldown() {
		this.enabled = true;
	}
}
