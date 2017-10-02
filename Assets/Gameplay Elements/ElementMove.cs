using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMove : MonoBehaviour {
	public float horizontalAmount;
	public float verticalAmount;
	public float horizontalSpeed;
	public float verticalSpeed;
	public bool horizontalForward;
	public bool verticalForward;
	public bool startBackHorizontal;
	public bool startBackVertical;
	GameObject controlla;
	float initialz;
	Vector2 startPosition;
	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		initialz = transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {
		if (!controlla.GetComponent<LevelControlla> ().paused) {
			
			float x = transform.position.x + horizontalSpeed;
			if (!horizontalForward) {
				x = transform.position.x - horizontalSpeed;
			}
			//transform.position = new Vector2 (x, transform.position.y);
			float checkForward = (transform.position.x - (startPosition.x));
			if (startBackHorizontal) {
				checkForward = horizontalAmount + (transform.position.x - (startPosition.x));
			}
			if (checkForward <= 0) {
				horizontalForward = true;
			} else if (checkForward >= horizontalAmount) {
				horizontalForward = false;
			}
			float y = transform.position.y + verticalSpeed;
			if (!verticalForward) {
				y = transform.position.y - verticalSpeed;
			}
			float checkVertical = transform.position.y - startPosition.y;
			if (startBackVertical) {
				checkVertical = verticalAmount + (transform.position.y - (startPosition.y));
			}
			if (checkVertical <= 0) {
				verticalForward = true;
			} else if (checkVertical >= verticalAmount) {
				verticalForward = false;
			}
			transform.position = new Vector3 (x, y, initialz);

		}
	}
}
