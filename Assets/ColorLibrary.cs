using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLibrary : MonoBehaviour {
	public static ColorLibrary colorLib;
	public Color red;
	public Color orange;
	public Color yellow;
	public Color green;
	public Color blue;
	public Color purple;
	public Color black;
	public Color grey;
	public Color white;
	public Color darkgrey;
	public Color lightgrey;
	// Use this for initialization
	void Awake ()
	{
		if (colorLib == null) {
			colorLib = this;
		} else if (colorLib != this) {
			Destroy (gameObject);
		}
	}
	void Start () {
		red = new Color (1, 0, 0);
		orange =  new Color (1, .549f, 0);
		yellow = Color.yellow;
		green = new Color (0, 1, 0);
		blue = new Color (0, 0, 1);
		purple = new Color (.6235f, 0, .7725f);
		grey = new Color (.5f, .5f, .5f);
		black = new Color (0, 0, 0);
		white = new Color (1, 1, 1);
		darkgrey = new Color (.2f, .2f, .2f);
		lightgrey = new Color (.7f, .7f, .7f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
