using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFromLS : MonoBehaviour {
	GameObject[] musicControlla;
	bool happenOnce;
	// Use this for initialization
	void Start () {
		musicControlla = GameObject.FindGameObjectsWithTag ("MusicControlla");

	}
	IEnumerator loadMM2() {
		AsyncOperation async = SceneManager.LoadSceneAsync("MainMenu");
		async.allowSceneActivation = false;
		while (async.progress < .9f) {
			yield return null;
		}
		async.allowSceneActivation = true;

		//yield return async;
		//Debug.Log("Loading complete");
	}
	IEnumerator loadMM()
	{
		yield return  new WaitForSeconds(2);
		ManageSaveData.control.Save ();
//		foreach (GameObject controlla in musicControlla) {
//			Destroy (controlla);
//		}
//		GameObject del = GameObject.FindGameObjectWithTag ("MusicControllaControlla");
//		Destroy (del);
		SceneManager.LoadScene ("MainMenu");

	}
	// Update is called once per frame
	void Update () {
		if(!happenOnce)
		StartCoroutine( loadMM2 ());
		happenOnce = true;
	}
}
