using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	Rigidbody2D rb2d;
	public float speed = 10;
	GameObject controlla;
	// Use this for initialization
	void Start ()
	{
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!controlla.GetComponent<LevelControlla> ().paused) {
			if (controlla.GetComponent<ManagePowerups> ().powerUps [1] == 1) {
				speed = 20;
			} else if (controlla.GetComponent<ManagePowerups> ().powerUps [1] == -1) {
				speed = 5;
			} else {
				speed = 10;
			}
			float h = Input.GetAxis ("Horizontal");
			float v = Input.GetAxis ("Vertical");
			Vector2 move = new Vector2 (h, v);
			rb2d.AddForce (move * speed);
	
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
	}
}
