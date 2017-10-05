using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour {
	GameObject cam;
	bool happenOnce;
	LevelControlla control;
	float maxTime;
	Text text;
	float startTime;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		control = LevelControlla.control;
		text = GetComponent<Text> ();
		happenOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (control.levelStart && happenOnce) {
			happenOnce = false;
			startTime = Time.time;
			maxTime = Time.time + control.levelTime;
		}
		if (!control.nextLevel) {
			text.text = "" + Mathf.Round (maxTime - Time.time);
			if (Time.time >= maxTime && control.levelStart) {
				print (Time.time - maxTime);
				control.timesUp = true;
			}
			text.color = new Color (1, 1, 1, 1);
			if (cam.GetComponent<Follow_Camera> ().followCamera == false) {
				text.color = new Color (1, 1, 1, 0);
			}
		}
	}
}
