using UnityEngine;
using System.Collections;

public class LaunchAtPlayer : MonoBehaviour {

	public FireControl FireControl;

	private bool m_launched = false;
	private string m_fireControlString;

	// Use this for initialization
	void Start () {
		m_fireControlString = FireControl.ToString();
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce(Vector3.down * 1f, ForceMode.Impulse);
		if (transform.position.y < Formation.MIN_Y) {
			Spacecraft craft = GetComponent<Spacecraft>();
			craft.SpacecraftType = SpacecraftType.None; // so I don't get points for it
			SendMessageUpwards("DirectHit", gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

	private void FireWeapon(FireCommand command) {
		if (!m_launched && command.FireControlString == m_fireControlString) {
			SendMessage("StopMoving");
			rigidbody.constraints = RigidbodyConstraints.None;
			rigidbody.AddForce(Vector3.down * 2f, ForceMode.Impulse);
			m_launched = true;
			this.enabled = true;
		}
	}
}
