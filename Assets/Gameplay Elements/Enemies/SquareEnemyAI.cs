using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareEnemyAI : MonoBehaviour {
	Rigidbody2D rb2d;
	public GameObject player;
	float detectionRadius = 7;
	public bool attacking;
	public int attackPhase;
	Vector2 size;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		size = new Vector2 (1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector2.Distance (transform.position, player.transform.position) <= detectionRadius && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.grey && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.white) {
			attacking = true;
		}
		if (player.GetComponent<SpriteRenderer> ().color == ColorLibrary.colorLib.grey || player.GetComponent<SpriteRenderer> ().color == ColorLibrary.colorLib.white) {
			attacking = false;
		}
		if (attacking) {
			GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
			attack ();
		} else
			attackPhase = 0;
		transform.localScale = size;

	}
	void attack()
	{
		switch(attackPhase)
		{
		case 0:
			size.x -= .01f;
			size.y -= .01f;
			if (size.x <= 0f) {
				size.x = 0f;
				size.y = 0f;
				StartCoroutine (waitForPhase2());
				attackPhase = 1;
			}
			break;
		case 2:
			size.x += .09f;
			size.y += .09f;
			if (size.x >= 1f && Vector2.Distance (transform.position, player.transform.position) >= size.x/2) {
				attackPhase = 3;
				StartCoroutine (waitForPhase4());
			}
			break;
		default:
			break;
		}
	}
	IEnumerator waitForPhase2()
	{
		yield return new WaitForSeconds (1);
		if (attackPhase == 1) {
			transform.position = new Vector2 (player.transform.position.x, player.transform.position.y);
			size.x = .5f;
			size.y = .5f;
			attackPhase = 2;
		}
	}
	IEnumerator waitForPhase4()
	{
		yield return new WaitForSeconds (2);
		attackPhase = 0;
	}
}
