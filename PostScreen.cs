using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// post screen control script, updates all the text feilds to show the 
// reason for loss or socre when game is won
public class PostScreen : MonoBehaviour {
	public Text Title;
	public Text PostMessage;
	public Text score;
	public Text jumpcount;


	void Awake(){


	}
	public void MakeScreen(string t, string message, string s, string jumps){
		Title.text = t;
		PostMessage.text = message;
		score.text = s;
		jumpcount.text = jumps;
	}

	public void back(){
		Application.LoadLevel (1);
	}

	// Use this for initialization
	void Start () {
		MakeScreen (PlayerData.postTitle, PlayerData.postMessage, PlayerData.score.ToString(), PlayerData.numOfJumps.ToString());
		PlayerData.resetStats ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
