using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCollectedCoins : MonoBehaviour {
	Text text;
	GameObject controlla;
	GameObject cam;
	LevelControlla control;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		control = LevelControlla.control;
	}
	
	// Update is called once per frame
	void Update () {

		text.text = "" + (control.coins.Length);//- control.collectedCoins);
		if (cam.GetComponent<Follow_Camera> ().followCamera == false) {
			text.text = "";	
		}
	}
}
