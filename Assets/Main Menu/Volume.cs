using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "VOLUME: " + Mathf.Round(ManageSaveData.control.soundMult * 100)+ "%";
		
	}
	void OnMouseDown()
	{
		ManageSaveData.control.soundMult += .1f;
		if (ManageSaveData.control.soundMult > 1.1f) {
			ManageSaveData.control.soundMult = 0f;
		}
	}
}
