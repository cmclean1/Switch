using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Announcer : MonoBehaviour {

	public static Announcer announcer;
	Text text;
	void Awake()
	{
		announcer = this;
		text = GetComponent<Text> ();
	}
	// Use this for initialization
	void Start () {
		//announcer.Display ("yes");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Display(string _text)
	{
		text.text = _text;
		text.CrossFadeAlpha (1,.01f, false);

		text.color = new Color(1f,1f,1f,1f);

		text.CrossFadeAlpha (0, 4, false);
	}
}
