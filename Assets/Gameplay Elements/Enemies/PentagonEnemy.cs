using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentagonEnemy : MonoBehaviour {
	public GameObject player;
	float detectionRadius = 5;
	public bool attacking;
	public GameObject bullet;
	public GameObject bullets;
	public float shootFrequency = 2;
	float currentTime;
	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null && Vector2.Distance (transform.position, player.transform.position) <= detectionRadius && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.grey && player.GetComponent<SpriteRenderer>().color != ColorLibrary.colorLib.white) {
			attacking = true;
		} else {
			attacking = false;
		}
		if (attacking) {
			GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
			Vector3 dis = (transform.position - player.transform.position);
			dis = Vector3.Normalize (dis);
			transform.rotation = Quaternion.LookRotation (Vector3.forward, transform.position - player.transform.position);
			if (Time.time > currentTime) {
				currentTime = Time.time + shootFrequency;
				bullet = Instantiate (bullets, transform.position, Quaternion.identity) as GameObject;
				bullet.GetComponent<Rigidbody2D> ().AddForce (dis*-100);
				print ("yes");
			}
		}
	}
	void attack()
	{
		

	}
}
