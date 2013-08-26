using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	private GameObject m_hero;

	void Awake() {
		print("Tester.Awake()");
	}
	
	
	// Use this for initialization
	void Start () {
		print("Tester.Start()");

		m_hero = GameObject.Find("Hero");
	
	}
	
	// Update is called once per frame
	void Update () {

		float fireAxisValue = Input.GetAxis("Fire1");
		if (fireAxisValue != 0) {
			print("Fire1 !!! " + fireAxisValue);
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
}