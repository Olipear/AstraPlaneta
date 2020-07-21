using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// main display controller script
public class MainDisplay : MonoBehaviour {

	private Text display;

	void OnEnable(){
		display = GetComponentInChildren<Text> ();
		MainLoop.updateDisplay += updateDisplay;
	}
	
	void OnDisable(){
		MainLoop.updateDisplay -= updateDisplay;
	}
	
	void updateDisplay(int index, string inputString){
		if (index == 0) {
			display.text = inputString;
		}
	}
}
