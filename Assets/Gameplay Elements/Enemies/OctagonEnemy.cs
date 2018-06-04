using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctagonEnemy : MonoBehaviour {

	Rigidbody2D rb2d;
	public GameObject player;
	float detectionRadius = 7;
	public bool attacking;
	Vector2 size;
	float transparency;
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
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= detectionRadius && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.grey && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.white) {
			attacking = true;
		} else {
			attacking = false;
		}
		if (attacking) {

			attack ();
		}
		if (!attacking) {
			rb2d.drag = 5;
		}
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= .5f) {
			rb2d.drag = 5;
		} 

		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= .8f && attacking) {
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
		float torque = Mathf.Sqrt ((rb2d.velocity.x * rb2d.velocity.x) + (rb2d.velocity.y * rb2d.velocity.y)) * 5;
		if (rb2d.velocity.x + rb2d.velocity.y < 0) {
			torque *= -1;
		}
		rb2d.AddTorque (torque);
		if (rb2d.angularVelocity > 400) {
			rb2d.angularVelocity = 400;
		}
		if (rb2d.angularVelocity < -400) {
			rb2d.angularVelocity = -400;
		}

	}

	void attack ()
	{
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
		Vector3 dis = (transform.position - player.transform.position);
		transparency = (detectionRadius/4 - Mathf.Sqrt ((dis.x * dis.x) + (dis.y * dis.y)))/(detectionRadius/4);
		rb2d.drag = 1;
		dis = Vector3.Normalize (dis);
		GetComponent<SpriteRenderer> ().color = new Color (ColorLibrary.colorLib.darkgrey.r, ColorLibrary.colorLib.darkgrey.g, ColorLibrary.colorLib.darkgrey.b, transparency);;
		
		rb2d.AddForce (dis * -Random.Range(9f,11f));
	}
}
