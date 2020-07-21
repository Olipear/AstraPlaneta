using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

// music controller script will change track every 4 minutes
public class MusicControl : MonoBehaviour {

	public AudioClip track1Start;
	public AudioClip track1loop;
	public AudioClip track2Start;
	public AudioClip track2Loop;
	public AudioClip track3Start;
	public AudioClip track3Loop;
	public AudioSource source;
	public AudioMixerSnapshot fadein;
	public AudioMixerSnapshot fadeout;
	private bool musicplaying;
	// Use this for initialization
	void Start (){
		StartCoroutine(music());
	}

	public void toggle(){
		if (musicplaying) {
			source.enabled = false;
			musicplaying = false;
		} else {
			source.enabled = true;
			musicplaying = true;
		}
	}

	IEnumerator music(){
		int i = 1;
		while (true) {
			StartCoroutine(playTrack(i));
			fadein.TransitionTo(2f);
       		if (i==3){i = 1;}
			yield return new WaitForSeconds(240f);
			fadeout.TransitionTo(2f);
			i++;
		}
	}

	IEnumerator playTrack (int i){
		AudioClip start;
		AudioClip loop;
		if (i == 1) {
			start = track1Start;
			loop = track1loop;
		} else if (i == 2) {
			start = track2Start;
			loop = track2Loop;
		} else {
			start = track3Start;
			loop = track3Loop;
		}
		source.PlayOneShot (start);
		yield return new WaitForSeconds (5f);
		source.clip = loop;
		source.Play ();
		yield break;

	}
}
