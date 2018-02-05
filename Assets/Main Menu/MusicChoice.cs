using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicChoice : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (ManageSaveData.control.whichMusic) {
		case 0:
			text.text = "SHUFFLEMODE";
			break;
		case 1:
			text.text = "SONG: ADVENTURE";
			break;
		case 2:
			text.text = "SONG: MYSTERY";
			break;
		case 3:
			text.text = "SONG: LAMENT";
			break;
		case 4:
			text.text = "SONG: WHAT";
			break;
		}
	}

	void OnMouseDown()
	{
		if (GetComponent<Button> ().enabled) {
			ManageSaveData.control.whichMusic++;
			if (ManageSaveData.control.whichMusic > 4) {
				ManageSaveData.control.whichMusic = 0;
			}
		}
	}
}
