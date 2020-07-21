using UnityEngine;
using System.Collections;

// for both the environmental and map stars 
// calculates the correct colour based off of the temperature (main sequence only) - see documentation 
// scales the star to false scale, with maximum radius of 5 units
// also animates the textures for both at the same time, as the material is shared between them
public class StarBehaviour : MonoBehaviour {
	private ProceduralMaterial substance;
	private Light halo;
	private Vector3 startScale;
	private float anim;

	public void AssignProperties(Star star){
		AssignST (star);
		AssignRAD (star);
	}

	void Awake(){
		startScale = transform.localScale;
		substance = GetComponent<Renderer>().sharedMaterial as ProceduralMaterial;
	}

	void AssignST(Star star){
		//stellar code as float from 0-1
		float sc = (float)star.ST * 0.0166f;
		float red, green, blue;
		if (sc<0.5){
			red=sc*2f;
			green=red;
			blue=1f;
		}
		else{
			red=1f;
			green=-((sc-.5f)*2f)*((sc-.5f)*2f)+1f;
			blue=-((sc-.5f)*3f)*((sc-.5f)*3f)+1f;
		}
		Color starColour = new Color(red, green, blue, 1f);
		substance.SetProceduralColor("StarColour", starColour);
		substance.SetProceduralFloat ("$randomseed", Random.Range(0, 10000));
	}

	void AssignRAD(Star star){
		float scale =(1-Mathf.Exp(-.5f*(float)star.radius))*5;
		transform.localScale= startScale * scale;
	}

	

	// Update is called once per frame
	void Update () {

		substance.SetProceduralFloat ("Animate", anim);
		if (anim >= 1f) {
				anim = 0f;
		} else {
				anim += 0.001f;
		}
		substance.RebuildTextures();
	}
}
