using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour {
	public GameObject button;
	bool activated;
	public int activateWhat;

	/* 0 = exist
	 * 1 = color/powergate on
	 * 2 = elementmove
	*/
	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (button.GetComponent<isButton> ().activated) {
			GetComponent<ElementMove> ().enabled = false;
		} else {
			GetComponent<ElementMove> ().enabled = true;

		}
	}
}
