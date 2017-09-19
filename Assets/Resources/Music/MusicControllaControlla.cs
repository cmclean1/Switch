using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllaControlla : MonoBehaviour
{
	public static MusicControllaControlla musicControl;
	GameObject[] musicControlla;
	int songNum;
	int num;
	void Awake()
	{
		if (musicControl == null) {
			DontDestroyOnLoad (gameObject);
			musicControl = this;
		} else if (musicControl != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");

	}
	
	// Update is called once per frame

	public void chooseSong()
	{
		switch (ManageSaveData.control.whichMusic) {
		case 0:
			songNum = Random.Range (1, 3);
			break;
		case 1:
			songNum = 1;
			break;
		case 2:
			songNum = 2;
			break;
		}
		foreach (GameObject controlla in musicControlla) {
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			int audType = aud.GetComponent<MusicControlla> ().type;
			bool audSwitch = aud.GetComponent<MusicControlla> ().Switch;
			if (audType == 1) {
				if (audSwitch) {
					num = 1;
				} else {
					num = 2;
				}
			}
			if (audType == 2) {
				if (audSwitch) {
					num = 3;
				} else {
					num = 4;
				}
			}
			if (audType == 3) {
				if (audSwitch) {
					num = 5;
				} else {
					num = 6;
				}
			}
			aud.clip = Resources.Load("Music/" + songNum + num) as AudioClip;
			aud.Play();
		}
	}

	void Update ()
	{
		bool restartMusic = true;
		foreach (GameObject controlla in musicControlla) {
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			if (aud.isPlaying && controlla.GetComponent<MusicControlla>().canPlay)
				restartMusic = false;
		}
		if (restartMusic == true) {
			musicControl.chooseSong ();
		}
	}
}
