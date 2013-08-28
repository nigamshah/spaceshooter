using UnityEngine;
using System;
using System.Collections;

public class RandomGenerator {

	private static int s_seed = 12345678;
	private static System.Random s_random;
	public static System.Random Random {
		get {
			if (s_random == null) {
				RandomGenerator.Init();
			}
			return s_random;
		}
	}

	public static void Init() {
		if (s_seed == 0) {
			s_seed = DateTime.Now.Millisecond;
		}

		Debug.Log("Seed = " + s_seed);
		s_random = new System.Random(s_seed);
	}


}
