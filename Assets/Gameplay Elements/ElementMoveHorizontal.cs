using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMoveHorizontal : MonoBehaviour {

	public float horizontalAmount;
	public float horizontalSpeed;
	public bool horizontalForward;
	public bool startBackHorizontal;
	public float offset;
	GameObject controlla;
	float initialz;
	Vector2 startPosition;
	public float stopTime;
	bool stop;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		initialz = transform.position.z;
		stop = false;
	}

	// Update is called once per frame
	void Update () {
		if (!controlla.GetComponent<LevelControlla> ().paused) {

			float x = transform.position.x + horizontalSpeed;
			if (horizontalForward) {
				offset += horizontalSpeed;
			}
			else if (!horizontalForward) {
				x = transform.position.x - horizontalSpeed;
				offset -= horizontalSpeed;

			}
			//transform.position = new Vector2 (x, transform.position.y);
			float checkForward = (transform.position.x - (startPosition.x));
			if (startBackHorizontal) {
				checkForward = horizontalAmount + (transform.position.x - (startPosition.x));
			}
			if (!startBackHorizontal) {
				if (offset < 0) {
					horizontalForward = true;

				} else if (offset > horizontalAmount) {
					horizontalForward = false;

				}
			} else {
				if (offset > 0) {
					horizontalForward = false;

				} else if (offset < -horizontalAmount) {
					horizontalForward = true;

				}
			}
		//	transform.position = new Vector3 (x, transform.position.y, initialz);
		}
	}
	IEnumerator Stop()
	{
		yield return new WaitForSeconds (stopTime);
		stop = false;
	}
}
