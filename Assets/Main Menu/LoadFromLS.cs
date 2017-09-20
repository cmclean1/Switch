using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFromLS : MonoBehaviour {
	GameObject[] musicControlla;
	// Use this for initialization
	void Start () {
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");

	}
	public void loadLevel(int whichlevel)
	{
		SceneManager.LoadScene ("Level" + whichlevel);
		foreach (GameObject controlla in musicControlla) {
			controlla.GetComponent<MusicControlla> ().canPlay = true;
			AudioSource aud = controlla.GetComponent<AudioSource> ();
			aud.Play();
		}
	}
	public void loadMM()
	{
		ManageSaveData.control.Save ();
		foreach (GameObject controlla in musicControlla) {
			Destroy (controlla);
		}
		GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
		Destroy (del);
		SceneManager.LoadScene ("MainMenu");

	}
	// Update is called once per frame
	void Update () {
		
	}
}
