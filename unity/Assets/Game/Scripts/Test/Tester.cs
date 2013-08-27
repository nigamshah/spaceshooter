using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	private GameObject m_hero;

	public GameObject Weapon1Bullet;
	public GameObject Weapon2Bullet;
	public GameObject Weapon3Bullet;

	private float cooldown;

	void Awake() {
		print("Tester.Awake()");
		cooldown = 0f;
	}
	
	
	// Use this for initialization
	void Start () {
		print("Tester.Start()");

//		m_hero = GameObject.Find("Hero");
	
	}
	
	// Update is called once per frame
	void Update () {

		// do a co-routine, here, it is faster
		if (cooldown > 0) {
			cooldown = Mathf.Max (0, cooldown - Time.deltaTime);
			print("cooldown = " + cooldown);
			return;
		}

		float fireAxisValue = Input.GetAxis("Fire1");
		if (fireAxisValue != 0) {
			print("Fire1 !!! " + fireAxisValue);
			Fire1();
		}

		fireAxisValue = Input.GetAxis("Fire2");
		if (fireAxisValue != 0) {
			print("Fire2 ??? " + fireAxisValue);
		}

		fireAxisValue = Input.GetAxis("Fire3");
		if (fireAxisValue != 0) {
			print("Fire3 +++ " + fireAxisValue);
		}
	}

	private void Fire1() {

//		Vector3 pos = m_hero.transform.position;
//		pos.y += 200f;

		print("attempting to fire");
		GameObject bullet = Instantiate (Weapon1Bullet, Vector3.zero, Quaternion.Euler(Vector3.zero)) as GameObject;
		cooldown = 0.5f;
		//bullet.transform.parent = transform;


	}
}