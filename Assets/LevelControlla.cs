using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControlla : MonoBehaviour
{
	public bool dead;
	public bool paused;
	public GameObject player;
	public bool nextLevel;
	public int whichLevel;
	public int maxLevel;
	GameObject[] musicControlla;

	// Use this for initialization
	void Start ()
	{
		dead = false;
		paused = false;
		Instantiate (player, transform.position, Quaternion.identity);
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0) && dead) {
			SceneManager.LoadScene ("Level" + whichLevel);	
			//Instantiate(player,transform.position,Quaternion.identity);
			dead = false;
		} else if (Input.GetKeyDown (KeyCode.Escape) && dead) {
			dead = false;
			foreach (GameObject controlla in musicControlla) {
				Destroy (controlla);
			}
			GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
			Destroy (del);
			SceneManager.LoadScene ("MainMenu");
		} else if (paused == true && Input.GetMouseButton (0)) {
			paused = false;
			Time.timeScale = 1;
		} else if (Input.GetKeyDown (KeyCode.Escape) && paused == false && Time.timeScale == 1 && dead == false && !nextLevel) {
			Time.timeScale = 0;
			paused = true;
		} else if (paused == true && Input.GetKeyDown (KeyCode.Escape)) {
			paused = false;
			Time.timeScale = 1;
			SceneManager.LoadScene ("MainMenu");
			foreach (GameObject controlla in musicControlla) {
				Destroy (controlla);
			}
			GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
			Destroy (del);
		} else if (Input.GetMouseButton (0) && nextLevel) {
			dead = false;
			nextLevel = false;
			if (whichLevel == maxLevel) {
				SceneManager.LoadScene ("MainMenu");
				foreach (GameObject controlla in musicControlla) {
					Destroy (controlla);
				}
				GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
				Destroy (del);
			} else {
				SceneManager.LoadScene ("Level" + (whichLevel + 1));	
			}

		} else if (Input.GetKeyDown (KeyCode.Escape) && nextLevel) {
			dead = false;
			nextLevel = false;
			foreach (GameObject controlla in musicControlla) {
				Destroy (controlla);
			}
			GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
			Destroy (del);
			SceneManager.LoadScene ("MainMenu");
		}
		
	}
}
