using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isButton : MonoBehaviour {
	public bool activated;
	public float alphaValue;
	bool invertAlpha;
	public buttonEffect[] button;
	bool[] originalValues;
	int activateType;
	int isActive;
	/* 0 = player press, always on
	 * 1 = player press, timer on
	 * 2 = on only when player press
	*/
	// Use this for initialization
	void Start () {
		isActive = 0;
		activated = false;
		invertAlpha = true;
		alphaValue = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!activated) {
			if (invertAlpha) {
				alphaValue -= .025f;
				if (alphaValue <= .25f) {
					invertAlpha = false;
				}
			} else {
				alphaValue += .025f;
				if (alphaValue >= 1f) {
					invertAlpha = true;
				}
			}
		}
		if (activated && isActive == 0) {
			isActive = 1;
			foreach (buttonEffect effectors in button) {
				switch (effectors.whichEffect) {
				case 0:
					effectors.element.SetActive (!effectors.element.activeSelf);
					break;
				case 1:
					effectors.element.GetComponent<ElementMoveHorizontal> ().enabled = !effectors.element.GetComponent<ElementMoveHorizontal> ().isActiveAndEnabled;
					break;
				case 2:
					effectors.element.GetComponent<ElementMoveVertical> ().enabled = !effectors.element.GetComponent<ElementMoveVertical> ().isActiveAndEnabled;
					break;
				case 3:
					effectors.element.GetComponent<ElementSpin> ().enabled = !effectors.element.GetComponent<ElementSpin> ().isActiveAndEnabled;
					break;
				case 4:
					effectors.element.GetComponent<Force> ().enabled = !effectors.element.GetComponent<Force> ().isActiveAndEnabled;
					break;
				case 5:
					effectors.element.GetComponent<ElementChangeColor> ().enabled = !effectors.element.GetComponent<ElementChangeColor> ().isActiveAndEnabled;
					break;
				case 6:
					effectors.element.GetComponent<ElementCircleMove> ().enabled = !effectors.element.GetComponent<ElementCircleMove> ().isActiveAndEnabled;
					break;
				case 7:
					effectors.element.GetComponent<isButton> ().enabled = !effectors.element.GetComponent<isButton> ().isActiveAndEnabled;
					break;
				}
			}
		}
	}
	[System.Serializable]
	public class buttonEffect{
		public GameObject element;
		public int whichEffect;
		/*
		 * 0 = exist
		 * 1 = move horizontal
		 * 2 = move vertical
		 * 3 = spin
		 * 4 = force
		 * 5 = changeColor script
		 * 6 = circle move
		 * 7 = is button
		 * */
	}
}
