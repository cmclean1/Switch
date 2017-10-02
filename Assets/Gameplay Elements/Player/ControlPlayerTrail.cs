using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerTrail : MonoBehaviour {
	TrailRenderer trail;
	// Use this for initialization
	void Start () {
		trail = GetComponent<TrailRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		trail.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
		trail.startWidth = gameObject.transform.localScale.x;
	}
}
