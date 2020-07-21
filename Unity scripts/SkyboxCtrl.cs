using UnityEngine;
using System.Collections;

// updates the stars in new solar systems
public class SkyboxCtrl : MonoBehaviour {

	public ProceduralMaterial substance;


	// Use this for initialization
	void awake () {

	}
	void OnEnable(){
		MainLoop.jump += jump;
	}
	void OnDisable(){
		MainLoop.jump -= jump;
	}

	void jump(){
		if (substance != null){
			substance.SetProceduralFloat("$randomseed", Random.seed);
			substance.RebuildTextures();
		}
	}
}
