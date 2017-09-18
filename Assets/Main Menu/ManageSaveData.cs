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

	// Use this for initialization
	void Awake ()
	{
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
	}

	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerinfo.dat");
		playerData data = new playerData ();
		data.levelUnlocked = levelUnlocked;
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/playerinfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
			playerData data = (playerData)bf.Deserialize (file);
			data.levelUnlocked = levelUnlocked;
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