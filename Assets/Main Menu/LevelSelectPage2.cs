using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPage2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<LevelSelect> ().levelPage--;
		if (GetComponent<LevelSelect> ().levelPage < 0) {
			GetComponent<LevelSelect> ().levelPage = 0;
		}
		GetComponent<LevelSelectPage2> ().enabled = false;
	}
}
