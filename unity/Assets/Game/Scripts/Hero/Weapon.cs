using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public enum FireAxis {
		Fire1, Fire2, Fire3
	}

	// public vars can be edited in Inspector

	public GameObject Bullet;
	public FireAxis InputAxis;
	public float Cooldown = 0.1f;
	
	private string m_inputAxisString;
	private Quaternion m_rotation;

	// Use this for initialization
	void Start() {
		Cooldown = Mathf.Max(0.1f, Cooldown);
		m_inputAxisString = InputAxis.ToString();
		m_rotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update() {
		float fireAxisValue = Input.GetAxis("Fire1");
		if (fireAxisValue != 0) {
			print("Fire1 !!! " + fireAxisValue);
			GameObject bullet = Instantiate(Bullet, Vector3.zero, m_rotation) as GameObject;
			this.enabled = false;
			Invoke("ResetCooldown", Cooldown);
		}
	}
	private void ResetCooldown() {
		this.enabled = true;
	}
}
