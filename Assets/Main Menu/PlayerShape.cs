using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShape : MonoBehaviour
{
	Text text;
	string whichShape;
	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (ManageSaveData.control.whichPlayer) {
		case 0: 	
			whichShape = "SQUARE";
			break;
		case 1:
			whichShape = "CIRCLE";
			break;
		case 2:
			whichShape = "TRIANGLE";
			break;
		case 3:
			whichShape = "PENTAGON";
			break;
		case 4:
			whichShape = "HEXAGON";
			break;
		}
		text.text = "SHAPE: " + whichShape;
	}

	void OnMouseDown ()
	{
		if (GetComponent<Button> ().enabled) {
			ManageSaveData.control.whichPlayer++;
			if (ManageSaveData.control.whichPlayer > 4) {
				ManageSaveData.control.whichPlayer = 0;
			}
		}
	}
	
}
