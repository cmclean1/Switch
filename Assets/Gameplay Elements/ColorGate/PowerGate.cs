using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGate : MonoBehaviour {
	public int whichPower;
	public bool upOrDown;
	public int powerAmount;
	// Use this for initialization
	void Start () {
		if (upOrDown) {
			powerAmount = 1;
		} else
			powerAmount = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (upOrDown) {
			GetComponent<ElementColorControl> ().type = 0;
			GetComponent<ElementColorControl> ().Switch = true;
		} else {
			GetComponent<ElementColorControl> ().type = 0;
			GetComponent<ElementColorControl> ().Switch = false;
		}
	}
}
