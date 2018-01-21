using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRevolve : MonoBehaviour {
	public float radius;
	public float speed;
	public int startingAxis;	
	float degree;
	public Vector2 offset;
	// Use this for initialization
	void Start () {
		if (startingAxis == 0) {
			degree = 0;
		} else if (startingAxis == 1) {
			degree = Mathf.PI / 2;
		} else if (startingAxis == 2) {
			degree = Mathf.PI;
		} else if (startingAxis == 3) {
			degree = 3 * Mathf.PI / 2;
		} else {
			degree = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		degree += speed;
		offset.x = Mathf.Cos (degree) * radius;
		offset.y = Mathf.Sin (degree) * radius;
		print (offset);
	}
}
