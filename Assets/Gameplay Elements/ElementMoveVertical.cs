using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMoveVertical : MonoBehaviour {
	public float verticalAmount;
	public float verticalSpeed;
	public bool verticalForward;
	public bool startBackVertical;
	GameObject controlla;
	float initialz;
	Vector2 startPosition;
	public float stopTime;
	public float offset;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		initialz = transform.position.z;

	}

	// Update is called once per frame
	void Update () {
		if (!controlla.GetComponent<LevelControlla> ().paused) {

			float x = transform.position.x + verticalSpeed;
			if (verticalForward) {
				offset += verticalSpeed;
			}
			else if (!verticalForward) {
				x = transform.position.x - verticalSpeed;
				offset -= verticalSpeed;

			}
			//transform.position = new Vector2 (x, transform.position.y);
			float checkForward = (transform.position.x - (startPosition.x));
			if (startBackVertical) {
				checkForward = verticalAmount + (transform.position.x - (startPosition.x));
			}
			if (!startBackVertical) {
				if (offset < 0) {
					verticalForward = true;

				} else if (offset > verticalAmount) {
					verticalForward = false;

				}
			} else {
				if (offset > 0) {
					verticalForward = false;
				} else if (offset < -verticalAmount) {
					verticalForward = true;
				}
			}
			//	transform.position = new Vector3 (x, transform.position.y, initialz);
		}
	}
}
