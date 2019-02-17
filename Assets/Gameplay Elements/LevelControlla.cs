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
	public bool levelStart = false;
	public GameObject player;
	public bool nextLevel;
	public int whichLevel;
	public int maxLevel;
	public GameObject arrow;
	public bool arrowOn;
	GameObject[] musicControlla;
	public GameObject[] coins;
	public string levelName;
	public int collectedCoins;
	Announcer announcer;
	public float levelTime;
	public bool timesUp;
	public bool allPoints;
	public bool beatTime;
	// Use this for initialization
	void Awake ()
	{
		control = this;
	}

	void Start ()
	{
		announcer = Announcer.announcer;
		announcer.Display ("LVL " + whichLevel + ": " + levelName);
		maxLevel = ManageSaveData.control.maxLevel;
		player = ManageSaveData.control.player;
		if (ManageSaveData.control.player == null) {
			player = Resources.Load ("SquarePlayer") as GameObject;
		}
		dead = false;
		paused = false;
		timesUp = false;
		//Instantiate (player, transform.position, Quaternion.identity);
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");
		if (whichLevel > ManageSaveData.control.levelUnlocked) {
			ManageSaveData.control.levelUnlocked = whichLevel;
		}
		if(arrowOn == true)
		{
			Instantiate(arrow);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		coins =  GameObject.FindGameObjectsWithTag ("Coin");
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
				if (allPoints) {
					ManageSaveData.control.allPoints [whichLevel] = true;
				}
				if (timesUp == false) {
					ManageSaveData.control.timeBeat [whichLevel] = true;
				}
				ManageSaveData.control.Save ();
				SceneManager.LoadScene ("MainMenu");
				foreach (GameObject controlla in musicControlla) {
					Destroy (controlla);
				}
				GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
				Destroy (del);
			} else {
				if (allPoints) {
					ManageSaveData.control.allPoints [whichLevel] = true;
				}
				if (timesUp == false) {
					ManageSaveData.control.timeBeat [whichLevel] = true;
				}
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
			if (allPoints) {
				ManageSaveData.control.allPoints [whichLevel] = true;
			}
			if (timesUp == false) {
				ManageSaveData.control.timeBeat [whichLevel] = true;
			}
			ManageSaveData.control.Save ();
			SceneManager.LoadScene ("MainMenu");
		}
		
	}
}
