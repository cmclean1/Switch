using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<LevelSelect> ().levelPage++;
		GetComponent<LevelSelectPage> ().enabled = false;
	}
}
