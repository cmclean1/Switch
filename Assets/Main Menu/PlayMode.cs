using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMode : MonoBehaviour {

	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		switch (ManageSaveData.control.playMode) {
		case 0:
			text.text = "PLAYMODE: WASD";
			break;
		case 1:
			text.text = "PLAYMODE: ARROWS";
			break;
		case 2:
			text.text = "PLAYMODE: MOUSE";
			break;
		}
	}
	void OnMouseDown()
	{
		if (GetComponent<Button> ().enabled) {
			ManageSaveData.control.playMode += 1;
			if (ManageSaveData.control.playMode > 2) {
				ManageSaveData.control.playMode = 0;
			}
		}
	}
}
