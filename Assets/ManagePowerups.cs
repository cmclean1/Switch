using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePowerups : MonoBehaviour {
	public int[] powerUps;
	/* Power list
	 * 0 = FOV
	 * 1 = Speed
	 * 2 = Mortality
	 * */
	// Use this for initialization
	void Start () {
		powerUps = new int[3];

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < powerUps.Length; i++) {
			if (powerUps [i] > 1) {
				powerUps [i] = 1;
			}  if (powerUps [i] < -1) {
				powerUps [i] = -1;
			}
		}

	}

}
