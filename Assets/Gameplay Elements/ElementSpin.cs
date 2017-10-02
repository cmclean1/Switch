using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpin : MonoBehaviour {
	public float speed;
	public float degrees;
	public bool forward;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float tempSpeed = speed;
		if (!forward) {
			tempSpeed = -speed;
		}
		if (degrees == 0) {
			gameObject.transform.Rotate(0,0,tempSpeed);
			//gameObject.transform.rotation.z += speed;
		}

	}
}
