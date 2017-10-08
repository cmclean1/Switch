using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPoints : MonoBehaviour
{
	SpriteRenderer[] scores;
	// Use this for initialization
	void Start ()
	{
		scores = GetComponentsInChildren<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (SpriteRenderer obj in scores) {
			obj.GetComponent<SpriteRenderer> ().enabled = false;
				
			if (GetComponent<Text> ().enabled == false) {
			} else {
				if (ManageSaveData.control.allPoints.Length > GetComponent<LoadLevel> ().whichlevel) {
					if (obj.tag == "Coin") {
						if (ManageSaveData.control.allPoints [GetComponent<LoadLevel> ().whichlevel] == true) {
							obj.GetComponent<SpriteRenderer> ().enabled = true;
						}
					}
					if (obj.tag == "Stopwatch") {
						if (ManageSaveData.control.timeBeat [GetComponent<LoadLevel> ().whichlevel] == true) {
							obj.GetComponent<SpriteRenderer> ().enabled = true;
						}
					}
				} else {
					obj.GetComponent<SpriteRenderer> ().enabled = false;

				}
			}
		}
	}
}