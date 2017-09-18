using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackgroundSummon : MonoBehaviour {
	float time;
	public float interval;
	public GameObject bg;
	// Use this for initialization
	void Awake()
	{
	}
	void Start () {
		time = Time.time;
		ManageSaveData.control.Load ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > time) {
			time += interval;
			Instantiate (bg);
		}
	}
}
