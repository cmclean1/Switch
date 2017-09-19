using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlla : MonoBehaviour
{
	// Use this for initialization
	public GameObject player;
	public int type;
	public bool Switch;
	AudioSource aud;
	public bool canPlay;
	public float soundMult;
	void Start ()
	{
		canPlay = false;
		DontDestroyOnLoad (gameObject);
		aud = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//print (player.GetComponent<ChangeColor> ().sp.color);
		soundMult = ManageSaveData.control.soundMult;
		player = GameObject.FindGameObjectWithTag ("Player");
		if (canPlay) {
			if ((player.GetComponent<ChangeColor> ().type == type && player.GetComponent<ChangeColor> ().Switch == Switch) || player.GetComponent<ChangeColor> ().sp.color == Color.black || player.GetComponent<ChangeColor> ().sp.color == Color.white) {
				aud.volume += (.005f*soundMult);
				if (aud.volume >= 1*soundMult) {
					aud.volume = 1*soundMult;
				}
			} else {
				aud.volume -= (.005f*soundMult);
				if (aud.volume <= (.3f*soundMult)) {
					aud.volume = (.3f*soundMult);
				}
			}
		}
	}
}
