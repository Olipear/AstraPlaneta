using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// controls the navigation display
public class NavDisplay : MonoBehaviour {
	private Text display;
	private Button NavButton;


	void OnEnable(){
		display = GetComponentInChildren<Text> ();
		NavButton = GetComponentInChildren<Button> ();
		MainLoop.updateDisplay += updateDisplay;
		MainLoop.regenSys += regenSys;
	}
	
	void OnDisable(){
		MainLoop.updateDisplay -= updateDisplay;
		MainLoop.regenSys -= regenSys;
	}
	// on update display event check who it's for and update the screen
	void updateDisplay(int index, string inputString){
		if (index == 1) {
				display.text = inputString;
				NavButton.interactable = true;
		}
	}
	// reset the screen whenever the system is regenerated
	void regenSys(){
		display.text = "Select Planet";
		NavButton.interactable = false;
	}

}
