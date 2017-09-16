using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllaControlla : MonoBehaviour
{
	GameObject[] musicControlla;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject);
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");

	}
	
	// Update is called once per frame
	void Update ()
	{
		bool restartMusic = true;
		foreach (GameObject controlla in musicControlla) {
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			if (aud.isPlaying && controlla.GetComponent<MusicControlla>().canPlay)
				restartMusic = false;
		}
		if (restartMusic == true) {
			foreach (GameObject controlla in musicControlla) {
				AudioSource aud = controlla.GetComponent<AudioSource> ();
				aud.Play();
			}
		}
	}
}
