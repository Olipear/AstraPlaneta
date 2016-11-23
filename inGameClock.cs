using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// system time, because the laptop should do someting.
public class inGameClock : MonoBehaviour {
	private Text disp;
	// Use this for initialization
	void Awake(){
		disp = GetComponent<Text> ();
	}
	void Start () {
		StartCoroutine (clock ());
	}

	IEnumerator clock(){
		while (true) {
			disp.text = System.DateTime.Now.ToShortTimeString();
			yield return new WaitForSeconds(60f);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
