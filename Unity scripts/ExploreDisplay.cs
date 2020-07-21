using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExploreDisplay : MonoBehaviour {
	private Text disp;

	void OnEnable(){
		MainLoop.updateDisplay += updateDisplay;
	}

	// Use this for initialization
	void OnDisable () {
		MainLoop.updateDisplay -= updateDisplay;
	}

	void updateDisplay(int i, string s){
		if (MainLoop.currentPlanet.explored){
			string report; 
			Planet p = MainLoop.currentPlanet.p;
			if (!p.habitable){
				report = "Planet is not suitable candidate \n";
				if (p.water < 0f){
					report += "We didn't find water,";
				} else{report += "We found water,";}
				if (p.thorium > 0f){report +=" and thorium was found.";
				}else{report += " and found no thorium.";}
				if (p.vegitation){report += "Theres also strange life forms, but we couldn't stand it down there long";}
				else{report += " The surface is barren, no signs of life anywhere";}
				disp.text = report;
			}else{
				disp.text = "We can survive here. It's up to you, shall we settle here or keep looking?";
			}
		}else if (i ==0){
			disp.text = "unexplored";
		}
	}
	
	// Update is called once per frame
	void Awake () {
		disp = GetComponent<Text> ();
	}
}
