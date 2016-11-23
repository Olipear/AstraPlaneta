using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// solar system generator controller, creates the map planets to display the star gen output
public class StarSysGen : MonoBehaviour {

	public GameObject HoloPlanet;
	public GameObject OrbitLine;
	public GameObject MapStar;
	private PlanetSysGen planetGen;
	private StarSystem SS;
	private StarBehaviour MapS;
	private StarBehaviour S;


	void Awake(){

		MapS = MapStar.GetComponent<StarBehaviour> ();
		planetGen = GetComponent<PlanetSysGen> ();
	}

	void OnEnable(){
		MainLoop.regenSys += regenSys;
	}

	void OnDisable(){
		MainLoop.regenSys -= regenSys;
	}

	// make a new star gen system, assign all the important values to the game objects
	// then forget the SS because it's no longer needed
	// difficulty setting determins how often a sun like star is generated 
	//(where a= 30 is highest probability of generating a start like our sun)
	void regenSys(){
		float bound = System.Math.Min((PlayerData.difficulty*100f)* PlayerData.numOfJumps, 100f)/100f * 30.0f;
		int starcode = (int) Random.Range(bound, 60f - bound);
		SS = new StarSystem (starcode);
		GenerateSystem ();
		SS = null;
	}

	// generates the nav deck objects, which hold all the information about the current system
	void GenerateSystem()
	{
		// if there's already a system being displayed then delete it
		if (MapStar.transform.childCount > 0){
			foreach (Transform childTransform in MapStar.transform){
				Destroy(childTransform.gameObject);
			}
		}
		// tell the starbehaviour how to behave
		MapS.AssignProperties (SS.primary);
		CreateMapPlanets ();
	}

	// add an orbit line for each map planet
	void drawOrbit (float offset, Transform parent){
		Transform clone = Instantiate (OrbitLine.transform, MapStar.transform.position, OrbitLine.transform.rotation) as Transform;
		clone.transform.parent = parent;
		clone.GetComponent<PlanetPath> ().drawOrbit (offset, 0f, offset);
	}


	// draw the map planets on the nav deck thingy
	void CreateMapPlanets()
	{
		// variable to make sure they are equally spaced apart - to scale makes the inner planets awkward to select
		float equalSpace = 0f;
		float d = ((1-Mathf.Exp(-.5f*(float)SS.primary.radius))*35f); // the distance d, from the star needs to change if the star is larger
		int planCount = SS.planets.Count -1;
		int RandomPlanet = (int)Random.Range (0f, planCount); // select a random planet to be the destination 
		for (int i = 0; i < planCount; i++) {
			//divide radius by earths radius so that 1 = earth radius.
			float scalef = (float) (SS.planets[i].radius/6371f);
			// squashes scale so that planets are a maximum of 0.32 units, clamped to minium of 0.16 units
			scalef = Mathf.Clamp((1-Mathf.Exp(-0.5f*scalef))*.32f, 0.16f, 0.32f);
			//Calculate distance from star in worldspace
			float distance = Mathf.Lerp (d, 85f, equalSpace);
			//set the position
			Vector3 orb_pos = new Vector3 (MapStar.transform.position.x+distance*Mathf.Cos((float)SS.planets[i].where_in_orbit), MapStar.transform.position.y, MapStar.transform.position.z+distance*Mathf.Sin((float)SS.planets[i].where_in_orbit));
			Transform clone = Instantiate(HoloPlanet.transform, orb_pos, HoloPlanet.transform.rotation) as Transform;
			drawOrbit (distance, MapStar.transform);
			clone.transform.parent = MapStar.transform;
			// set the scale as a ratio of original size, allows for easy scale change via prefab scale
			clone.transform.localScale = new Vector3(scalef,scalef,scalef);
			// put the planet object in the planet gameobject
			MapPlanetBehaviour mapPlanet = clone.GetComponent<MapPlanetBehaviour>();
			mapPlanet.p = SS.planets[i];
			mapPlanet.generateDisText();
			mapPlanet.parentpos = MapStar.transform.position;
			equalSpace = equalSpace+(1f/SS.planets.Count);
			if (i == RandomPlanet){ // for the selected planet, make it the current and highlight it, rengerate planet is called from here. 
				MainLoop.currentPlanet = mapPlanet;
				mapPlanet.highlight(1);
				planetGen.assignPlanet(mapPlanet);
			}
		}
	}
}
