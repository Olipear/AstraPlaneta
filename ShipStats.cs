using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// interfaces the playerData with the ship's display panels. 
// sets the panel colours if the resource is running low
// plays a sound when they are low
public class ShipStats: MonoBehaviour {
	// just holds some references for the images
	public Image fuelBar;
	public Image waterBar;
	public Image popBar;	
	private int noWater;

	void OnEnable(){
		MainLoop.updateDisplay += updateDisplay;
	}
	void OnDisable(){
		MainLoop.updateDisplay -= updateDisplay;
	}

	void updateDisplay(int i, string s){
		updateScreens ();
	}

	// update screens called whenever any of the displays are updated
	// gives a voice notification at certain levels
	public void updateScreens(){
		fuelBar.fillAmount = PlayerData.fuel;
		waterBar.fillAmount = PlayerData.water;
		popBar.fillAmount = PlayerData.population;
			updateColours (fuelBar, 1);
			updateColours (waterBar, 2);
			updateColours (popBar, 0);
			if (PlayerData.fuel <= 0.2f) {
				if (PlayerData.fuel <= 0f) {
					PlayerData.Lose (0);
				} else {
					MainLoop.sounds.voiceNotification (1);
				}
			}
		if (PlayerData.population <= 0f) {
				PlayerData.Lose (1);
			}
		if (PlayerData.water <= 0.2f) {
			if (PlayerData.water <= 0f) {
				noWater += 1;
				PlayerData.population -= 0.03f * noWater;
					MainLoop.sounds.voiceNotification (3);
				} else {
					MainLoop.sounds.voiceNotification (2);
				}
			} else {
				noWater = 0;
			}
		}

	private void updateColours(Image img, int type){
		if (img.fillAmount <= 0.5) {
			if (img.fillAmount <= 0.2) {
				img.color = new Color (0.93f, 0.36f, 0.04f);
			} else {				
				img.color = new Color (0.93f, 0.57f, 0.04f);
			}
		} else {
			img.color = new Color (1f, 1f, 1f);
		}
	}

}
