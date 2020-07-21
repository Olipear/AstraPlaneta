using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// static class to hold game information and controls win/loss conditions
public static class PlayerData {

	static public int numOfJumps;
	static private int noWater;
	static public float highscore;
	static public float fuel;
	static public float water;
	static public float population;
	static public ShipStats infopanels;
	static public string postTitle;
	static public string postMessage;
	static public float score;
	static public float difficulty = 10f; 


	// Use this for initialization
	static void Awake () {
		resetStats ();
	}
	
	static public void Lose(int lossCode){
		//Handheld.PlayFullScreenMovie("LoseAnimation.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		postTitle = "Failure";
		switch (lossCode) {
			case 0:
				postMessage = "You ran out of thorium to fuel your ship. Survey rocky planets to find thorium. Your ship uses more Thorium when jumping to a new system.";
				break;
			case 1:
				postMessage = "Your ship ran out of water, causing your colonists to starve. Water is rare, but can be found on some rocky planets, and gas giants with rings made from ice.";
				break;
		}
		Application.LoadLevel (4);
	}
	static public void Win(float s){
		postTitle = "Success";
		score = s*population*numOfJumps;
		if (score > highscore) {
			highscore = score;
		}
		Application.LoadLevelAsync (4);
	}

	static public void resetStats(){
		postTitle=null;
		postMessage=null;
		numOfJumps = 0;
		fuel = 1f;
		water = 1f;
		population = 1f;
		score = 0;
	}





}
