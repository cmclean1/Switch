using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
	Color[] colors;
	 int start;
	/* 0 = right
	 * 1 = bottom
	 * 2 = left
	 * 3 = top
	 */
	Vector3 move;
	Vector3 velocity;
	public float speed;
	// Use this for initialization
	void Start ()
	{
		GetComponent<SpriteRenderer> ().color = new Color (Random.value, Random.value, Random.value);
		colors = new Color[] {Color.blue, Color.green, Color.red, Color.cyan, Color.yellow, Color.magenta};
		GetComponent<SpriteRenderer> ().color = colors[Random.Range(0,colors.Length-1)];
		start = Mathf.RoundToInt (Random.value * 3);
		if (start == 0) {
			transform.position = new Vector3 (30, 0, 5);
			velocity = new Vector3 (-speed, 0, 0);
		} else if (start == 1) {
			transform.position = new Vector3 (0, -30, 5);
			velocity = new Vector3 (0, speed, 0);

		} else if (start == 2) {
			transform.position = new Vector3 (-30, 0, 5);
			velocity = new Vector3 (speed, 0, 0);

		} else if (start == 3) {
			transform.position = new Vector3 (0, 30, 5);
			velocity = new Vector3 (0, -speed, 0);

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		StartCoroutine (die ());
		velocity = new Vector3 (velocity.x, velocity.y, velocity.z + .1f);
		move = (Vector3)(transform.position + velocity);
		transform.position = move;
		if (transform.position.x == 0 && transform.position.y == 0) {
			velocity = new Vector3 (0, 0,  velocity.z);
		}
	}
	IEnumerator die()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
