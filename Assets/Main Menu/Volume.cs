using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		text.text = "VOLUME: " + Mathf.Round(ManageSaveData.control.soundMult * 100)+ "%";

	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Button> ().enabled) {
			ManageSaveData.control.soundMult += .1f;
			if (ManageSaveData.control.soundMult > 1.01f) {
				ManageSaveData.control.soundMult = 0f;
			}
		}
		text.text = "VOLUME: " + Mathf.Round(ManageSaveData.control.soundMult * 100)+ "%";
		GetComponent<Volume> ().enabled = false;
		
	}
	void OnMouseDown()
	{
		
	}
}
