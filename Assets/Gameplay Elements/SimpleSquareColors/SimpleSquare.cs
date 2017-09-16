using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSquare : MonoBehaviour {
	SpriteRenderer sp;
	 int type;
	 bool Switch;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();

		if (type == 0) {
			if (Switch == false) {
				sp.color = new Color (0, 0, 0);
			} else
				sp.color = new Color (1, 1, 1);
		} else if (type == 1) {
			if (Switch == false) {
				sp.color = Color.red;
			} else
				sp.color = Color.green;
		}
		else if (type == 2) {
			if (Switch == false) {
				sp.color = new Color (1, .647f, 0);
			} else
				sp.color = Color.blue;
		}
		else if (type == 3) {
			if (Switch == false) {
				sp.color = Color.yellow;
			} else
				sp.color = Color.magenta;
		}
	}
	
	// Update is called once per frame
	void Update () {
		type = GetComponent<ElementColorControl> ().type;
		Switch = GetComponent<ElementColorControl> ().Switch;
		if (type == 0) {
			if (Switch == false) {
				sp.color = new Color (0, 0, 0);
			} else
				sp.color = new Color (1, 1, 1);
		} else if (type == 1) {
			if (Switch == false) {
				sp.color = Color.red;
			} else
				sp.color = Color.green;
		}
		else if (type == 2) {
			if (Switch == false) {
				sp.color = new Color (1, .647f, 0);
			} else
				sp.color = Color.blue;
		}
		else if (type == 3) {
			if (Switch == false) {
				sp.color = Color.yellow;
			} else
				sp.color = Color.magenta;
		}
	}
}
