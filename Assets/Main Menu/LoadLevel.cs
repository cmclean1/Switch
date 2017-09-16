
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	public int whichlevel;
	GameObject[] musicControlla;
	// Use this for initialization
	void Start () {
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");
	}
	
	// Update is called once per frame
	void Update () {
		SceneManager.LoadScene ("Level" + whichlevel);
		foreach (GameObject controlla in musicControlla) {
			controlla.GetComponent<MusicControlla> ().canPlay = true;
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			aud.Play();
		}

	}
}
