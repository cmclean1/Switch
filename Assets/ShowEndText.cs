using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEndText : MonoBehaviour {
	public GameObject controlla;
	Text text;
	// Use this for initialization
	void Start () {
		controlla = GameObject.FindGameObjectWithTag ("Controlla");
		text = GetComponent<Text> ();
		text.color = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (controlla.GetComponent<LevelControlla> ().nextLevel == true) {
			text.text = "Level Complete\nNEXT LEVEL: LMB\nMAIN MENU: ESC";
			text.color = new Color (0, 0, 0, 1);

		} else if (controlla.GetComponent<LevelControlla> ().dead == true) {
			text.text = "Level Failed\n RESTART: LMB\n MAIN MENU: ESC";
			text.color = new Color (0, 0, 0, 1);


		} else if (controlla.GetComponent<LevelControlla> ().paused == true) {
			text.text = "Paused\n RESUME: LMB\n MAIN MENU: ESC";
			text.color = new Color (0, 0, 0, 1);
		} else {
			text.color = new Color (0, 0, 0, 0);

		}
	}
}
