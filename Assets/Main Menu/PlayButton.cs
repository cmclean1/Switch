using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
	GameObject[] musicControlla;
	GameObject controlla;
	// Use this for initialization
	void Start () {
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");
	}
	
	// Update is called once per frame
	void Update () {
		
		SceneManager.LoadScene ("Level1");	
		foreach (GameObject controlla in musicControlla) {
			controlla.GetComponent<MusicControlla> ().canPlay = true;
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			aud.Play();
		}
	}
	void OnMouseUp(){
		SceneManager.LoadScene ("Level1");	
		MusicControllaControlla.musicControl.chooseSong ();
		foreach (GameObject controlla in musicControlla) {
			controlla.GetComponent<MusicControlla> ().canPlay = true;
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			aud.Play();
		}

	}
}
