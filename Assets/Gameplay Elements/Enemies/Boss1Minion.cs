using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Minion : MonoBehaviour
{
	Rigidbody2D rb2d;
	public GameObject player;
	float detectionRadius = 7;
	public bool attacking;
	public bool launched;
	Vector2 size;
	Boss1 parent;
	// Use this for initialization
	void Start ()
	{
		launched = true;
		parent = GameObject.FindGameObjectWithTag ("Boss").GetComponent<Boss1> ();
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.AddForce (Random.insideUnitCircle * 200);
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
		size = new Vector2 (1f, 1f);


	}

	void attack ()
	{
		if (!LevelControlla.control.paused && player != null) {
			Vector3 dis = (transform.position - player.transform.position);
			rb2d.drag = 1;
			dis = Vector3.Normalize (dis);
			rb2d.AddForce (dis * -5);
		}
	}

	void returnToBoss ()
	{
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		Vector3 dis = (transform.position - parent.transform.position);
		rb2d.drag = 1;
		dis = Vector3.Normalize (dis);
		rb2d.AddForce (dis * -5);
		if (Vector2.Distance (transform.position, parent.transform.position) <= .5f) {
			Vector2 temp = parent.transform.localScale;
			temp = new Vector2 (parent.transform.localScale.x + .05f, parent.transform.localScale.y + .05f);
			parent.transform.localScale = temp;
			Destroy (gameObject);
		}
	}

	void Update ()
	{
		// Update is called once per frame
		player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
		if (player != null) {
			if (Vector2.Distance (transform.position, player.transform.position) <= detectionRadius && parent.stage == 1) {
				attacking = true;
			} else {
				attacking = false;
			}
			if (attacking) {
				launched = false;
				attack ();
			}
			if (!attacking && !launched) {
				rb2d.drag = 5;
			}
			if (Vector2.Distance (transform.position, player.transform.position) <= .5f) {
				rb2d.drag = 5;
			} 
			if (parent.stage == 2) {
				returnToBoss ();
			}
			if (parent.stage == 3) {
				Destroy (gameObject);
			}
			if (Vector2.Distance (transform.position, player.transform.position) <= .8f && attacking) {
				size.x += .2f;
				size.y += .2f;
			} else {
				size.x -= .1f;
				size.y -= .1f;
				if (size.x <= 1f) {
					size.x = 1f;
					size.y = 1f;

				}
			}
			if (Vector2.Distance (transform.position, parent.transform.position) > 30 && !attacking && parent.stage != 2) {
				rb2d.velocity = new Vector2 (0, 0);
			}
			transform.localScale = size;
		}
	}
}
