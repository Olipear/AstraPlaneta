using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Main Controller class for in game events and functions
public class MainLoop : MonoBehaviour {	
	// update display panel event, index of panel to update, then text to update it with.
	// 0 - desk display panel
	// 1 - nav display panel
	// 2 - jump info panel
	public delegate void updisp(int index, string inputString);
	public static event updisp updateDisplay;

	public delegate void regnerateSystem ();
	public static event regnerateSystem regenSys;

	public delegate void regeneratePlanet(MapPlanetBehaviour p);
	public static event regeneratePlanet regenPlanet;

	public delegate void preparetojump();
	public static event preparetojump preJump;

	public delegate void GoToPlanet();
	public static event GoToPlanet jump;

	public float scrollspeed;
	private Vector2[] TouchOrigin = new Vector2[2];
	private bool UIenabled;
	public static SoundFX sounds;
	public Button settleButton;
	public static MapPlanetBehaviour currentPlanet;
	public static MapPlanetBehaviour selectedPlanet;

	void Awake(){
		sounds = GetComponent<SoundFX>();
		settleButton.interactable =false;

	}
	IEnumerator Start(){
		if (preJump != null){preJump();}
		yield return new WaitForSeconds (8);
		if (regenSys != null) {regenSys();}
		yield return new WaitForSeconds (1);
		// give it time to load so you don't see the textures change
		yield return new WaitForSeconds (10f);
		if (jump != null){jump();}
		if(updateDisplay != null){updateDisplay(0, currentPlanet.descriptionLong);}
		UIenabled = true;
	}

	public void jumpButton(){
		if (UIenabled) {
			sounds.buttonPress();
			UIenabled = false;
			StartCoroutine(jumpSequence());
		}
	}
	
	public void OrbitButton(){
		if (UIenabled && selectedPlanet != null) {
			UIenabled = false;
			sounds.buttonPress ();
			StartCoroutine(changePlanet(selectedPlanet));
		}
	}

	public void ExitButton(){
		if (UIenabled) {
			sounds.buttonPress ();
			UIenabled = false;
			Application.LoadLevelAsync(1);
		}
	}                     

	public void exploreButton(){
		if (UIenabled && !currentPlanet.explored) {
			sounds.buttonPress ();
			UIenabled = false;
			StartCoroutine(exploreSequence());
		}
	}

	public void SettleButton(){
		if (UIenabled) {
			sounds.buttonPress ();
			UIenabled = false;
			PlayerData.Win((float)currentPlanet.p.howHabitable);
		}
	}

	private IEnumerator jumpSequence(){
		// tell everthing the ship is about to change position
		if (preJump != null){preJump();}
		yield return new WaitForSeconds (8);
		if (regenSys != null) {regenSys();}
		yield return new WaitForSeconds (1);
		// give it time to load so you don't see the textures change
		yield return new WaitForSeconds (14f);
		if (jump != null){jump();}
		//StartCoroutine(playVideo ("JumpAnimation.mp4"));
		PlayerData.water -= 0.05f*PlayerData.population;
		PlayerData.fuel -=0.1f;
		if(updateDisplay != null){updateDisplay(0, currentPlanet.descriptionLong);}
		PlayerData.numOfJumps += 1;
		yield return new WaitForSeconds (10);
		UIenabled = true;
		yield return null;
	}



	private IEnumerator changePlanet(MapPlanetBehaviour destination){
		// tell everthing the ship is about to change position
		if (preJump != null){preJump();}
		// wait for prejump stuff to be done
		yield return new WaitForSeconds (8);
		if (regenPlanet != null) {regenPlanet(destination);}
		yield return new WaitForSeconds (1);
		// give it time to load so you don't see the textures change
		yield return new WaitForSeconds (14f);
		currentPlanet.highlight(2);
		selectedPlanet.highlight(1);
		currentPlanet = selectedPlanet;
		if (jump != null){jump();}
		//StartCoroutine(playVideo ("JumpAnimation.mp4"));
		currentPlanet.highlight(2);
		selectedPlanet.highlight(1);
		currentPlanet = selectedPlanet;
		selectedPlanet = null;
		PlayerData.water -= 0.05f * PlayerData.population;
		PlayerData.fuel -= 0.03f;
		if(updateDisplay != null){updateDisplay(0, currentPlanet.descriptionLong);}
		yield return new WaitForSeconds (10);
		UIenabled = true;
		yield break;
	}

	private IEnumerator exploreSequence(){
		//StartCoroutine(playVideo ("ScoutLeave.mp4"));
		yield return new WaitForSeconds(2);
		sounds.voiceNotification (0);
		yield return new WaitForSeconds(2);
		PlayerData.fuel += (float)currentPlanet.p.thorium;
		PlayerData.water += (float)currentPlanet.p.water;
		currentPlanet.explored = true;
		if (currentPlanet.p.habitable == true) {
			yield return new WaitForSeconds (2);
			sounds.voiceNotification (4);
			settleButton.interactable =true;
		}
		if(updateDisplay != null){updateDisplay(0, currentPlanet.descriptionLong);}
		UIenabled = true;
		yield break; 
	}

	//private IEnumerator playVideo(string url){
		//Handheld.PlayFullScreenMovie(url, Color.black, FullScreenMovieControlMode.CancelOnInput);
		//yield return new WaitForEndOfFrame();
		//yield return new WaitForEndOfFrame();
	//}


	// function if a stationary touch or click
	void Click(Vector2 position){
		// origin of the raycast
		Ray origin = Camera.main.ScreenPointToRay(position);
		// info about what is hit
		RaycastHit hit;
		if(Physics.Raycast (origin, out hit)){ //if it hits the planet
			if (UIenabled){
				sounds.buttonPress ();
				if (selectedPlanet != null){
					selectedPlanet.highlight(0);
					selectedPlanet.GetComponent<Collider>().enabled = true;
				}			
				selectedPlanet = hit.collider.GetComponent<MapPlanetBehaviour> ();
				if(updateDisplay != null){updateDisplay(1, selectedPlanet.descriptionShort);}
				selectedPlanet.highlight(3);
				hit.collider.enabled = false;	
			}
		}
	}

	// if a single finger swipe
	void scroll(Vector2 pos, float len){
		Vector3 a = new Vector3 (pos.y, -pos.x, 0f);
		Camera[] cams = Camera.allCameras;
		a = Camera.main.transform.localEulerAngles + (a*(len/(Screen.height*1.5f)));
		if (a.x >= 20f && a.x <= 337f) {
			// don't rotate to see floor or ceiling 
		} else {
			Camera.main.transform.localEulerAngles = a;
			foreach (Camera c in cams) {
				c.transform.localRotation = Camera.main.transform.localRotation;
			}
		}

	}

	void Zoom(Touch[] touches){
		// Find the magnitude of the vector (the distance) between the touches in each frame.
		float prevTouchDeltaMag = (TouchOrigin [0] - TouchOrigin [1]).magnitude;
		float touchDeltaMag = (touches [0].position - touches [1].position).magnitude;
		// Find the difference in the distances between each frame.
		float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
		Camera.main.fieldOfView += deltaMagnitudeDiff * 0.2f;			
		Camera.main.fieldOfView = Mathf.Clamp (Camera.main.fieldOfView, 15f, 52.9f);	
		TouchOrigin [0] = touches [0].position;
		TouchOrigin [1] = touches [1].position;

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Click (Input.mousePosition);
		}
		if (Input.GetMouseButton (1)) {
			scroll(
		}
	}

}
