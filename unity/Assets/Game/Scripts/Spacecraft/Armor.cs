using UnityEngine;
using System.Collections;

public class Armor : MonoBehaviour {

	public int StartingArmorPoints = 10;

	// TODO: Change back to private
	public float m_armorPoints;

	// Use this for initialization
	void Start () {
		m_armorPoints = (float) StartingArmorPoints;
		if (m_armorPoints > 0) {
			SendMessage("EnableArmor");
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		Projectile projectile = collision.gameObject.GetComponent<Projectile>();
		
		if (projectile != null) {
			float damage = projectile.Damage;
			m_armorPoints -= damage;
			if (m_armorPoints < 0) {
				SendMessage("DirectHit", SendMessageOptions.DontRequireReceiver);
			} else if (m_armorPoints == 0) {
				SendMessage("ArmorFailed", SendMessageOptions.DontRequireReceiver);
			}
		}
	}

}
