using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonBullet : MonoBehaviour {
	Vector2 size;
	public GameObject player;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		size = new Vector2 (1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");

		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= .8f) {
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

		StartCoroutine (die ());

	}
	IEnumerator die()
	{
		yield return new WaitForSeconds (10);
		DestroyObject (gameObject);
	}
}
