using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour {

	public int StartingArmorPoints = 10;

	private float m_armorPoints;

	// Use this for initialization
	void Start () {
		m_armorPoints = (float) StartingArmorPoints;
	}
	
	// Update is called once per frame
	void Update () {
		// maybe some kind of armor regeneration?
	
	}

	void OnCollisionEnter(Collision collision) {
		Projectile projectile = collision.gameObject.GetComponent<Projectile>();

		if (projectile != null) {
			float damage = projectile.Damage;

			if (m_armorPoints == 0) {
				SendMessage("DirectHit", projectile, SendMessageOptions.DontRequireReceiver);
			} else {
				m_armorPoints = Mathf.Max(0, m_armorPoints - damage);
				if (m_armorPoints == 0) {
					SendMessage("ArmorFailed", SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

}
