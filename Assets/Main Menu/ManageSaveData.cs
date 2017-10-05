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
	public int maxLevel;
	public float soundMult;
	public int playMode;
	public GameObject player;
	public bool[] allPoints;
	public bool[] timeBeat;
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
		maxLevel = 9;
		if (allPoints.Length < maxLevel + 1) {
			bool[] temp = new bool[maxLevel+1];
			for (int i = 0; i < allPoints.Length; i++) {
				temp [i] = allPoints [i];
			}
			allPoints = temp;
			temp = new bool[maxLevel+1];
			for (int i = 0; i < timeBeat.Length; i++) {
				temp [i] = timeBeat [i];
			}
			timeBeat = temp;
		}

	}

	void Start ()
	{
		whichPlayer = 0;
		whichMusic = 2;
		soundMult = 1f;

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
		else if (whichPlayer == 3) {
			player = Resources.Load ("PentagonPlayer") as GameObject;
		}
		else if (whichPlayer == 4) {
			player = Resources.Load ("HexagonPlayer") as GameObject;
		}

	}

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/saveData.dat");
		playerData data = new playerData ();
		data.levelUnlocked = levelUnlocked;
		data.allPoints = allPoints;
		data.timeBeat = timeBeat;
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
			allPoints = data.allPoints;
			timeBeat = data.timeBeat;
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
	public bool[] allPoints;
	public bool[] timeBeat;
}