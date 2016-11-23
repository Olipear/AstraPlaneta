using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

// Main menu controller saves and loads to player prefs file, can always 
// be accessed on any device regardless of install location
public class MainMenu : MonoBehaviour {

	public Text highcore;

	// Use this for initialization
	void Start () {
		if (PlayerData.numOfJumps == 0) {
			Load ();
		}
		Save ();
		highcore.text = "HighScore:" + PlayerData.highscore.ToString();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void NewGame(){
		PlayerData.resetStats ();
		Application.LoadLevel (3);
	}

	public void Continue(){
		Application.LoadLevel (3);
	}

	public void Exit(){
		Save();
		Application.Quit();
	}

	public void setDifficulty(float i){
		PlayerData.difficulty = i;
	}

	void Save(){
		PlayerPrefs.SetInt ("jumps", PlayerData.numOfJumps);
		PlayerPrefs.SetFloat ("fuel", PlayerData.fuel);
		PlayerPrefs.SetFloat ("water", PlayerData.water);
		PlayerPrefs.SetFloat ("pop", PlayerData.population);
		PlayerPrefs.SetFloat ("highscore", PlayerData.highscore);
		PlayerPrefs.SetFloat ("difficulty", PlayerData.difficulty);

	}
	void Load(){
		PlayerData.numOfJumps = PlayerPrefs.GetInt ("jumps", 0);
		PlayerData.fuel = PlayerPrefs.GetFloat ("fuel", 1f);
		PlayerData.water = PlayerPrefs.GetFloat ("water", 1f);
		PlayerData.population = PlayerPrefs.GetFloat ("pop", 1f);
		PlayerData.highscore = PlayerPrefs.GetFloat ("highscore", 0f);
		PlayerData.difficulty = PlayerPrefs.GetFloat ("difficulty", 100f);
	}
}