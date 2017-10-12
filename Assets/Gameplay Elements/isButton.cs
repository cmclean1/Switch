using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isButton : MonoBehaviour {
	public bool activated;
	public float alphaValue;
	bool invertAlpha;
	public buttonEffect[] button;
	/* 0 = player press, always on
	 * 1 = player press, timer on
	 * 2 = on only when player press
	*/
	// Use this for initialization
	void Start () {
		activated = false;
		invertAlpha = true;
		alphaValue = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated) {
			if (invertAlpha) {
				alphaValue -= .025f;
				if (alphaValue <= .25f) {
					invertAlpha = false;
				}
			} else {
				alphaValue += .025f;
				if (alphaValue >= 1f) {
					invertAlpha = true;
				}
			}
		}
	}
	public class buttonEffect{
		GameObject ganobject;
		int effectWhat;
	}
}
