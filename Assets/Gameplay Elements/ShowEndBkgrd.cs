using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEndBkgrd : MonoBehaviour {
	public GameObject controlla;
	LevelControlla control;
	Image image;
	// Use this for initialization
	void Start () {
		control = LevelControlla.control;
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		image = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (control.nextLevel == true || control.dead == true || control.paused == true) {
			image.color = new Color (image.color.r, image.color.g, image.color.b, 1);
		} else {
			image.color = new Color (image.color.r, image.color.g, image.color.b, 0);

		}
	}
}
