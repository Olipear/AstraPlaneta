using UnityEngine;
using System.Collections;

// controls movement of the orbital camera, ie the imaginary ship
public class ShipMovement : MonoBehaviour {
	private Animator anim;
	void OnEnable(){
		MainLoop.preJump += preJump;
		MainLoop.jump += jump;
	}

	void OnDisable(){
		MainLoop.jump -= jump;
		MainLoop.preJump -= preJump;
	}

	void preJump(){
		anim.applyRootMotion = true;
		anim.SetTrigger ("LeavePlanet");
	}

	void jump(){
		anim.applyRootMotion = false;
		if (MainLoop.currentPlanet.p.gas_giant == true) {
				anim.SetTrigger ("DoneWaitingGas");
		} else {
				anim.SetTrigger ("DoneWaiting");
		}
	}

	void Awake(){
		anim = GetComponent<Animator> ();
	}
}
