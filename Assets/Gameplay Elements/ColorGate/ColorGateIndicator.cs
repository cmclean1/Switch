using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGateIndicator : MonoBehaviour {
	float scale;
	float startime;
	public GameObject player;
	// Use this for initialization
	void Start () {
		startime = Time.time;
		player = GameObject.FindGameObjectWithTag ("Player");
		StartCoroutine (die());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -2.25f);
		scale = 1- (Time.time - startime) / 2;
		gameObject.transform.localScale = new Vector2 (scale, scale);
	}
	IEnumerator die()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
