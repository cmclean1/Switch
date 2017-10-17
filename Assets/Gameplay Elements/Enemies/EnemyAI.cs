using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	Rigidbody2D rb2d;
	public GameObject player;
	float detectionRadius = 7;
	public bool attacking;
	Vector2 size;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		size = new Vector2 (1f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector2.Distance (transform.position, player.transform.position) <= detectionRadius && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.grey && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.white) {
			attacking = true;
		} else {
			attacking = false;
		}
		if (attacking) {
			GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;

			attack ();
		}
		if (!attacking) {
			rb2d.drag = 5;
		}
		if (Vector2.Distance (transform.position, player.transform.position) <= .5f) {
			rb2d.drag = 5;
		} 

		if (Vector2.Distance (transform.position, player.transform.position) <= .8f) {
			size.x += .11f;
			size.y += .11f;
		} else {
			size.x -= .1f;
			size.y -= .1f;
			if (size.x <= 1f) {
				size.x = 1f;
				size.y = 1f;

			}
		}
		transform.localScale = size;

	}

	void attack ()
	{
		Vector3 dis = (transform.position - player.transform.position);
		rb2d.drag = 1;
		dis = Vector3.Normalize (dis);
		rb2d.AddForce (dis * -10);
	}
}
