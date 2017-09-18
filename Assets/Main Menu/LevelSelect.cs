using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
	int maxLevel;
	public GameObject controlla;
	public GameObject text;
	public int levelPage;
	public int levelsPerPage;
	Text[] texts;
	// Use this for initialization
	void Start () {
		levelsPerPage = 9;
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		texts = GetComponentsInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < levelsPerPage; i++) {
			texts [i].GetComponent<Button> ().enabled = true;
			texts [i].text = "[" + (i+(levelsPerPage*levelPage)) + "]";
			texts [i].GetComponent<LoadLevel> ().whichlevel = (i + (levelsPerPage * levelPage))	;
			if (GetComponent<Image> ().enabled) {
				texts [i].GetComponent<Text>().enabled = true;
				if (ManageSaveData.control.levelUnlocked >= texts [i].GetComponent<LoadLevel> ().whichlevel) {
					texts [i].GetComponent<Button> ().interactable = true;
				} else {
					texts [i].GetComponent<Button> ().interactable = false;
				}
			} else {
				texts [i].GetComponent<Text>().enabled = false;
				texts [i].GetComponent<Button> ().interactable = false;
				levelPage = 0;

			}
		}
	}
}
