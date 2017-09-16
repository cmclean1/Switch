using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEndBkgrd : MonoBehaviour {
	public GameObject controlla;
	Image image;
	// Use this for initialization
	void Start () {
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		image = GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (controlla.GetComponent<LevelControlla> ().nextLevel == true || controlla.GetComponent<LevelControlla> ().dead == true || controlla.GetComponent<LevelControlla> ().paused == true) {
			image.color = new Color (image.color.r, image.color.g, image.color.b, 1);
		} else {
			image.color = new Color (image.color.r, image.color.g, image.color.b, 0);

		}
	}
}
