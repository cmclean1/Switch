using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleEnemy : MonoBehaviour {

	Rigidbody2D rb2d;
	public GameObject player;
	float detectionRadius = 7;
	public bool attacking;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		print (transform.position.x);

		//GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= detectionRadius && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.grey && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.white) {
			attacking = true;
		} else {
			attacking = false;
		}
		attacking = true;
		if (attacking) {
			//GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
			attack ();
		}
//		if (!attacking) {
//			rb2d.drag = 5;
//		}
//		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= .5f) {
//			rb2d.drag = 5;
//		} 
	}

	void attack ()
	{
		Vector3 dis = (transform.position - player.transform.position);
		rb2d.drag = 1;
		dis = Vector3.Normalize (dis);
		rb2d.AddForce (dis * -Random.Range(9f,11f));
	}
}
