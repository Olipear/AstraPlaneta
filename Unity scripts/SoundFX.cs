using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

// seperate class to access sound effects
public class SoundFX : MonoBehaviour {

	public AudioClip jumpNoise;
	public AudioClip ButtonPress;
	public AudioClip JumpWarningSound;
	public AudioClip WaterWarning;
	public AudioClip WaterCritical;
	public AudioClip FuelWarning;
	public AudioClip ExplorationDone;
	public AudioClip IsHabitable;
	public AudioSource audioSource;
	private bool repeating;
	void Start() {
	}

	void OnEnable(){
		MainLoop.preJump += preJump;
		MainLoop.jump += jump;
	}

	void OnDisable(){
		MainLoop.preJump -= preJump;
		MainLoop.jump -= jump;
	}
	// public function for button press
	public void buttonPress(){
		audioSource.PlayOneShot(ButtonPress);
	}

	//event functions
	void jump(){
		audioSource.PlayOneShot(jumpNoise);
	}
	void preJump(){
		StartCoroutine (alarmSound());
	}

	// play the alarm sound  
	private IEnumerator alarmSound (){
		yield return new WaitForSeconds (5f);
		audioSource.PlayOneShot (JumpWarningSound);
		yield break;
	}
	 
	// plays voice depending on code
	 public void voiceNotification(int noticeCode){
		// wait unil the last message/ effect has stopped
		while (audioSource.isPlaying) {	}
		switch (noticeCode) {
			case 0:
				audioSource.PlayOneShot(ExplorationDone);
				break;
			case 1:
				audioSource.PlayOneShot(FuelWarning);
				break;
			case 2:
				audioSource.PlayOneShot(WaterWarning);
				break;
			case 3:
				audioSource.PlayOneShot(WaterCritical);
				break;
			case 4:
				audioSource.PlayOneShot(IsHabitable);
				break;
		}
	}
}
