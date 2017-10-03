using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControlla : MonoBehaviour
{
	public static LevelControlla control;
	public bool dead;
	public bool paused;
	public GameObject player;
	public bool nextLevel;
	public int whichLevel;
	public int maxLevel;
	GameObject[] musicControlla;
	public string levelName;
	Announcer announcer;

	// Use this for initialization
	void Awake ()
	{
		control = this;
	}

	void Start ()
	{
		announcer = Announcer.announcer;
		announcer.Display (levelName);
		player = ManageSaveData.control.player;
		if (ManageSaveData.control.player == null) {
			player = Resources.Load ("SquarePlayer") as GameObject;
		}
		dead = false;
		paused = false;
		Instantiate (player, transform.position, Quaternion.identity);
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");
		if (whichLevel > ManageSaveData.control.levelUnlocked) {
			ManageSaveData.control.levelUnlocked = whichLevel;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && dead) {
			ManageSaveData.control.Save ();
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
			ManageSaveData.control.Save ();
			SceneManager.LoadScene ("MainMenu");
		} else if (paused == true && Input.GetMouseButtonDown (0)) {
			paused = false;
			Time.timeScale = 1;
		} else if (Input.GetKeyDown (KeyCode.Escape) && paused == false && Time.timeScale == 1 && dead == false && !nextLevel) {
			Time.timeScale = 0;
			paused = true;
		} else if (paused == true && Input.GetKeyDown (KeyCode.Escape)) {
			paused = false;
			Time.timeScale = 1;
			ManageSaveData.control.Save ();
			foreach (GameObject controlla in musicControlla) {
				Destroy (controlla);
			}
			GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
			Destroy (del);
			SceneManager.LoadScene ("MainMenu");
		} else if (Input.GetMouseButtonDown (0) && nextLevel) {
			dead = false;
			nextLevel = false;
			if (whichLevel == maxLevel) {
				ManageSaveData.control.Save ();
				SceneManager.LoadScene ("MainMenu");
				foreach (GameObject controlla in musicControlla) {
					Destroy (controlla);
				}
				GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
				Destroy (del);
			} else {
				ManageSaveData.control.Save ();
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
			ManageSaveData.control.Save ();
			SceneManager.LoadScene ("MainMenu");
		}
		
	}
}
