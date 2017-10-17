using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {
	public static Boss1 boss;
	public GameObject[] forces;
	public GameObject minions;
	public GameObject min;
	public GameObject[] allMinions;
	public GameObject colorGate;
	public GameObject[] colorGateLocations;
	public GameObject summonedColorGate;
	public GameObject player;
	int damaged;
	public int stage;
	bool vulnerable;
	/*
	 * 0 = shrink to summon enemies
	 * 1 = stay small
	 * 2 = grow back
	 * 3 = damaged
	 */
	// Use this for initialization
	void Awake()
	{
		boss = this;
	}
	void Start () {
		damaged = 0;
		stage = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	// Update is called once per frame
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player");
		GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.grey;
		if (stage == 0) {
			min = Instantiate (minions, transform.position, Quaternion.identity) as GameObject;
			//if (damaged > 0) {
			//	min = Instantiate (minions, transform.position, Quaternion.identity) as GameObject;
			//}
			//if (damaged > 1) {
			//	min = Instantiate (minions, transform.position, Quaternion.identity) as GameObject;
			//}
			//Instantiate (minions, transform.position, Quaternion.identity);
			Vector2 temp = transform.localScale;
			temp = new Vector2 (transform.localScale.x - .05f, transform.localScale.y - .05f);
			transform.localScale = temp;
			if (transform.localScale.x <= 10) {
				stage = 1;
				StartCoroutine (waitForStage2 ());
			}
		} else if (stage == 2) {
			print (vulnerable);
			GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.darkgrey;
			allMinions = GameObject.FindGameObjectsWithTag ("Minion");
			if (allMinions.Length == 0) {
				StartCoroutine (waitBtw2And1 ());
				foreach (GameObject force in forces) {
					force.GetComponent<Force> ().enabled = true;
				}
			}
			if (player.GetComponent<ChangeColor> ().touchedGate) {
				vulnerable = true;
			}
			if (Vector2.Distance (transform.position, player.transform.position) <= transform.localScale.x / 2f && vulnerable) {
				stage = 3;
				damaged++;
				vulnerable = false;
				Destroy (summonedColorGate);
			}
		} else if (stage == 3) {
			GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.lightgrey;
			Vector2 temp = transform.localScale;
			player.GetComponent<ChangeColor> ().invincible = true;
			if (transform.localScale.x <= -20 || transform.localScale.x == 20) {
				temp = new Vector2 (20, 20);
				transform.localScale = temp;
				StartCoroutine (gotHurt ());
			} else {
				temp = new Vector2 (transform.localScale.x - .15f, transform.localScale.y - .15f);
				transform.localScale = temp;
			}
		} else if (stage == 4) {
			gameObject.tag = "Goal";
			GetComponent<SpriteRenderer> ().color = ColorLibrary.colorLib.white;

		}
	}
	IEnumerator waitForStage2()
	{
		int waitTime;
		if (damaged == 0) {
			waitTime = 5;
		} else if (damaged == 1) {
			waitTime = 10;
		} else if (damaged == 2) {
			waitTime = 15;
		} else if (damaged == 3) {
			waitTime = 20;
		} else {
			waitTime = 5;
		}
		yield return new WaitForSeconds (waitTime);
		foreach (GameObject force in forces) {
			force.GetComponent<Force> ().enabled = false;
		}
		int random = Random.Range (0, 3);
		if (random >= 0 && random <= 1) {
			summonedColorGate = Instantiate (colorGate, colorGateLocations [random].transform.position, Quaternion.identity) as GameObject;
		} else {
			summonedColorGate = Instantiate (colorGate, colorGateLocations [random].transform.position, Quaternion.Euler(0,0,90)) as GameObject;

		}
		stage = 2;
	}
	IEnumerator gotHurt()
	{
		yield return new WaitForSeconds (2);
		foreach (GameObject force in forces) {
			force.GetComponent<Force> ().enabled = true;
		}	
		vulnerable = false;
		stage = 0;
		if (damaged == 3) {
			stage = 4;
			foreach (GameObject force in forces) {
				force.GetComponent<Force> ().enabled = false;
			}	
		}
		player.GetComponent<ChangeColor> ().invincible = false;

	}
	IEnumerator waitBtw2And1()
	{
		yield return new WaitForSeconds (2);
		Destroy (summonedColorGate);
		vulnerable = false;
		stage = 0;
	}
}
