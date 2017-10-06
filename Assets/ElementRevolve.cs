using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRevolve : MonoBehaviour {
	public float radius;
	public float speed;
	float degree;
	public Vector2 offset;
	// Use this for initialization
	void Start () {
		degree = 0;
	}
	
	// Update is called once per frame
	void Update () {
		degree += speed;
		offset.x = Mathf.Cos (degree) * radius;
		offset.y = Mathf.Sin (degree) * radius;
		print (offset);
	}
}
