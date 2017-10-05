using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatchPic : MonoBehaviour {
	GameObject cam;
	Image img;
	GameObject controlla;
	LevelControlla control;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		img = GetComponent<Image> ();
		control = LevelControlla.control;

	}

	// Update is called once per frame
	void Update () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");

		img.color = new Color (1, 1, 1, 1);
		if (cam.GetComponent<Follow_Camera> ().followCamera == false) {
			img.color = new Color (1, 1, 1, 0);
		}
		else if(control.timesUp == true)
		{
			img.color = new Color (.5f, .5f, .5f, 1);

		}
	}
}
