using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Camera : MonoBehaviour {
	public GameObject player;
	public GameObject controlla;
	bool inOrOut;
	// Use this for initialization
	void Start () {
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
	}
	
	// Update is called once per frame
	void LateUpdate () {
		player = GameObject.FindGameObjectWithTag ("Player");
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
		if (controlla.GetComponent<ManagePowerups> ().powerUps [0] == 1) {
			inOrOut = true;
			GetComponent<Camera> ().orthographicSize += .1f;
			if (GetComponent<Camera> ().orthographicSize >= 8) {
				GetComponent<Camera> ().orthographicSize = 8;
			}
		} else if (controlla.GetComponent<ManagePowerups> ().powerUps [0] <= -1) {
			inOrOut = false;
			GetComponent<Camera> ().orthographicSize -= .1f;
			if (GetComponent<Camera> ().orthographicSize <= 3) {
				GetComponent<Camera> ().orthographicSize = 3;
			}
		} else {
			if (inOrOut) {
				GetComponent<Camera> ().orthographicSize -= .1f;
				if (GetComponent<Camera> ().orthographicSize <= 5) {
					GetComponent<Camera> ().orthographicSize = 5;
				}
			} else {
				GetComponent<Camera> ().orthographicSize += .1f;
				if (GetComponent<Camera> ().orthographicSize >= 5) {
					GetComponent<Camera> ().orthographicSize = 5;
				}
			}
		}
	}
}
