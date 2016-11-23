using UnityEngine;
using System.Collections;
// alarm light controller
// could be expanded to have different colours on other events 
public class AlarmLight : MonoBehaviour {
	private Light warninglight;
	private AudioSource alarm;
	private bool flashing;

	void Awake(){
		warninglight = GetComponent<Light> ();
		alarm = GetComponent<AudioSource> ();
		flashing = false;
		alarm.enabled = false;
	}

	void OnEnable(){
		MainLoop.preJump += preJump;
		MainLoop.jump += jump;
	}
	
	void OnDisable(){
		MainLoop.preJump -= preJump;
		MainLoop.jump -= jump;
	}

	void preJump(){
		flashing = true;
		StartCoroutine (flashLight());
		alarm.enabled = true;
	}
	void jump(){
		flashing = false;;
		alarm.enabled = false;
	}
	
	private IEnumerator flashLight(){
		while(flashing){
			yield return new WaitForSeconds(0.5f);
			warninglight.enabled = true;
			yield return new WaitForSeconds(0.5f);
			warninglight.enabled = false;
		}
		yield break; 
	}

}
