using UnityEngine;
using System.Collections;

// environment sun roation, is affected by day length (spin) of planet
// the sun moves fast on rapidly spinning planets 
public class SunRotation : MonoBehaviour {

	private Vector3 position;
	private float OrbitSpeed;
	// Use this for initialization
	void Awake(){
		position = transform.parent.transform.position;
	}

	void Start () {

	}

	void OnEnable(){
		MainLoop.jump += jump;
	}
	void OnDisable(){
		MainLoop.jump -= jump;
	}
	// update orbit speed everytime the ship changes position
	void jump(){
		OrbitSpeed = (float)MainLoop.currentPlanet.p.day / 1000f;
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (position, Vector3.right, OrbitSpeed * Time.deltaTime);
	}
}
