using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSquare : MonoBehaviour {
	SpriteRenderer sp;
	 int type;
	 bool Switch;
	string color;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
		switch (color) {
		case "white":
			sp.color = new Color (0, 0, 0);
			break;
		case "black":
			sp.color = new Color (1, 1, 1);
			break;
		}
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
		color = GetComponent<ElementColorControl> ().color;
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
		if (GetComponent<isButton> () != null) {
			if (!GetComponent<isButton> ().activated) {
				Color temp = sp.color;
				temp.a = GetComponent<isButton> ().alphaValue;
				sp.color = temp;
				//sp.color = new Color (sp.color.r, sp.color.g, sp.color.b, GetComponent<isButton> ().alphaValue);
			} else {
				Color temp = sp.color;
				temp.a = 1f;
				sp.color = temp;
			}
		}
	}
}
