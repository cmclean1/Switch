using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClearSaveData : MonoBehaviour {
	int areYouSure;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (text.enabled == false) {
			areYouSure = 0;
		}
		if (areYouSure == 3) {
			GetComponent<Button> ().interactable = false;
		} else {
			GetComponent<Button> ().interactable = true;

		}
		if (areYouSure == 0) {
			text.text = "CLEAR SAVE DATA";
		} else if (areYouSure == 1) {
			text.text = "Are You Sure?";
		} else if (areYouSure == 2) {
			text.text = "One more time";
		} else if (areYouSure == 3) {
			text.text = "Save Data Gone!";
		}
	}
	void OnMouseDown()
	{
		if (GetComponent<Button> ().enabled && GetComponent<Button> ().interactable) {
			if (areYouSure < 3) {
				areYouSure++;
			}
			if (areYouSure == 3) {
				ManageSaveData.control.levelUnlocked = 9;
				ManageSaveData.control.allPoints = new bool[ManageSaveData.control.maxLevel + 1];
				ManageSaveData.control.timeBeat = new bool[ManageSaveData.control.maxLevel + 1];

				ManageSaveData.control.Save ();
			}
		}
	}
}
