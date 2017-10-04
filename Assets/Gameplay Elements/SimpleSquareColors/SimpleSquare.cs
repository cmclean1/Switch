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
			sp.color = ColorLibrary.colorLib.white;
			break;
		case "black":
			sp.color = ColorLibrary.colorLib.black;
			break;
		}
		if (type == 0) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.black;
			} else
				sp.color = ColorLibrary.colorLib.white;
		} else if (type == 1) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.red;
			} else
				sp.color = ColorLibrary.colorLib.green;
		}
		else if (type == 2) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.orange;
			} else
				sp.color = ColorLibrary.colorLib.blue;
		}
		else if (type == 3) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.yellow;
			} else
				sp.color = ColorLibrary.colorLib.purple;
		}
	}
	
	// Update is called once per frame
	void Update () {
		type = GetComponent<ElementColorControl> ().type;
		Switch = GetComponent<ElementColorControl> ().Switch;
		color = GetComponent<ElementColorControl> ().color;
		if (type == 0) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.black;
			} else
				sp.color = ColorLibrary.colorLib.white;
		} else if (type == 1) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.red;
			} else
				sp.color = ColorLibrary.colorLib.green;
		}
		else if (type == 2) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.orange;
			} else
				sp.color = ColorLibrary.colorLib.blue;
		}
		else if (type == 3) {
			if (Switch == false) {
				sp.color = ColorLibrary.colorLib.yellow;
			} else
				sp.color = ColorLibrary.colorLib.purple;
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
