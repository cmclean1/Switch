using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ManageSaveData : MonoBehaviour
{
	public static ManageSaveData control;
	public int levelUnlocked;
	public int whichPlayer;
	public int whichMusic;
	public GameObject player;
	// Use this for initialization
	void Awake ()
	{
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
		control.Load ();
	}

	void Start ()
	{
		whichPlayer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (whichPlayer == 0) {
			player = Resources.Load ("SquarePlayer") as GameObject;
		} else if (whichPlayer == 1) {
			player = Resources.Load ("CirclePlayer") as GameObject;
		} else if (whichPlayer == 2) {
			player = Resources.Load ("TrianglePlayer") as GameObject;

		}
	}

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/saveData.dat");
		playerData data = new playerData ();
		data.levelUnlocked = levelUnlocked;
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/saveData.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/saveData.dat", FileMode.Open);
			playerData data = (playerData)bf.Deserialize (file);
			levelUnlocked = data.levelUnlocked;
			file.Close ();
		}

	}
}

[Serializable]
class playerData
{
	public int levelUnlocked;
	public int whichPlayer;
	public int whichMusic;
}