using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;


public class Follow_Camera : MonoBehaviour {
	public GameObject player;
	public GameObject controlla;
	public bool followCamera = false;
	public Vector4[] panLocations;
	bool happenOnce = true;
	Vector2 offset;
	bool inOrOut;
	int whichLocation = 0;
	// Use this for initialization
	void Start () {
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
		GetComponent<ScreenOverlay> ().intensity = -1;
	}
	void panLevel()
	{
		if (happenOnce) {
			GetComponent<ScreenOverlay> ().intensity = -1;
			happenOnce = false;
		}
		if (panLocations.Length > whichLocation) {
			if (Input.GetMouseButtonDown (0)) {
				whichLocation = panLocations.Length + 1;
			}
			GetComponent<Camera> ().orthographicSize = 8;
			transform.position = new Vector3 (panLocations [whichLocation].x + offset.x, panLocations [whichLocation].y + offset.y, -10);
			Vector2 temp = offset;
			if (panLocations [whichLocation].w == 0) {
				temp = new Vector2 (temp.x += .08f, temp.y);
				GetComponent<ScreenOverlay> ().intensity += .08f;
				if (GetComponent<ScreenOverlay> ().intensity > 0) {
					GetComponent<ScreenOverlay> ().intensity = 0;
				}
			} else {
				temp = new Vector2 (temp.x, temp.y+= .08f);
				GetComponent<ScreenOverlay> ().intensity += .08f;
				if (GetComponent<ScreenOverlay> ().intensity > 0) {
					GetComponent<ScreenOverlay> ().intensity = 0;
				}
			}
			offset = temp;
			if (offset.x > panLocations[whichLocation].z || offset.y > panLocations[whichLocation].z) {
				whichLocation++;
				offset = new Vector2 (0, 0);
				GetComponent<ScreenOverlay> ().intensity = -1;
			}
		} else {
			GetComponent<Camera> ().orthographicSize = 5;
			followCamera = true;
			GetComponent<ScreenOverlay> ().intensity = 0;
		}
	}
	void Update()
	{
		if (!followCamera) {
			panLevel ();
		}
	}
	// Update is called once per frame
	void LateUpdate () {
		if (followCamera) {
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
}
