using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChangeColor : MonoBehaviour {
	public int[] types;
	public bool[] Switches;
	public float timeInterval;
	Color selected;
	float time;
	int whichColor;
	// Use this for initialization
	void Start () {
		time = Time.time + timeInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time) {
			time = Time.time + timeInterval;
			whichColor++;
			if (whichColor > types.Length-1) {
				whichColor = 0;
			}
		}
		GetComponent<ElementColorControl> ().type = types [whichColor];
		GetComponent<ElementColorControl> ().Switch = Switches [whichColor];;

	}
}
