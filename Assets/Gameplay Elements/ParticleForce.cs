using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleForce : MonoBehaviour {
	// Use this for initialization
	public bool die;
	public bool goDie;
	void Start () {
		die = false;
        transform.localScale = new Vector3(1/transform.parent.localScale.x * .09f, 1/transform.parent.localScale.y * .09f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelControlla.control.paused == false) {
			Rigidbody2D rb2d = GetComponent<Rigidbody2D> ();
			float vel = GetComponentInParent<Force> ().strength;
			switch (GetComponentInParent<Force> ().direction) {
			case 0:
				rb2d.AddForce (new Vector2 (vel, 0));
				break;
			case 1:
				rb2d.AddForce (new Vector2 (0, -vel));
				break;
			case 2:
				rb2d.AddForce (new Vector2 (-vel, 0));		
				break;
			case 3:
				rb2d.AddForce (new Vector2 (0, vel));
				break;
			}
			Collider2D[] cols = Physics2D.OverlapPointAll (transform.position);
			die = true;
			foreach (Collider2D col in cols) {
				if (col == GetComponentInParent<Collider2D> ()) {
					die = false;
				}
			}
			if(die == true)
				Destroy (gameObject);
			
		}

	}
}
