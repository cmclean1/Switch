using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementColorControl : MonoBehaviour {
	public int type;
	public bool Switch;
	public string color;
	Vector2 totalOffset;
	Vector2 initialPosition;
	// Use this for initialization
	void Start () {
		initialPosition = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		totalOffset = new Vector2 (0, 0);
		if (GetComponent<ElementMoveHorizontal>() != null) {
			//Vector2 temp = totalOffset;
			totalOffset.x += GetComponent<ElementMoveHorizontal>().offset;
			//totalOffset = temp;
		}
		if (GetComponent<ElementMoveVertical>() != null) {
			totalOffset.y += GetComponent<ElementMoveVertical>().offset;
		}
		if (GetComponent<ElementRevolve> () != null) {
			totalOffset += GetComponent<ElementRevolve> ().offset;
		}
		transform.position = new Vector2 (initialPosition.x+totalOffset.x,initialPosition.y+totalOffset.y);
	}
}
