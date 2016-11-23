using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// generates the planet's textures
public class PlanetSysGen : MonoBehaviour {

	public GameObject TPlanet;
	public GameObject GPlanet;

	// on creation listen to event and unsubscribe on destruction 
	void OnEnable(){
		MainLoop.regenPlanet += regenPlanet;
	}
	void OnDisable(){
		MainLoop.regenPlanet -= regenPlanet;
	}

	// regneratePlanet event causes planet to be rebuilt
	void regenPlanet(MapPlanetBehaviour p){
		assignPlanet (p);
	}

	// deletes the planet, then either makes a gas or rocky planet
	public void assignPlanet(MapPlanetBehaviour p){
		if (transform.childCount > 0){
			foreach (Transform childTransform in transform){
				Destroy(childTransform.gameObject);
			}
		}
		if (p.p.gas_giant) {
			StartCoroutine(MakeGasGiant(p));
		} else {StartCoroutine(MakePlanet(p));}
	}


	// Asyncronously builds the texture from the generated planet statistics
	IEnumerator MakePlanet(MapPlanetBehaviour p){
		Transform clone = Instantiate(
			TPlanet.transform,
			transform.position,
			transform.rotation) as Transform;
		//float scalef = (float) (p.radius/6371);
		clone.parent = transform;
		clone.transform.Rotate (Vector3.up, 90f);
		var substance = clone.GetComponent<Renderer>().sharedMaterial as ProceduralMaterial;
		GameObject atmos = clone.GetChild (0).gameObject;
		var atmosphere = atmos.GetComponent<Renderer>().sharedMaterial as ProceduralMaterial;
		substance.SetProceduralFloat("$randomseed", Random.seed);
		substance.SetProceduralBoolean ("Vegitation", p.p.rivers); 
		substance.SetProceduralFloat("Water", (float)p.p.hydrosphere);
		float craters = Mathf.InverseLerp(0f, 1000f, Mathf.Clamp((float) p.p.surf_pressure, 0, 1000f));
		substance.SetProceduralFloat("Craters", craters);
		substance.SetProceduralFloat("Moutains", craters-1f);
		substance.SetProceduralColor("PrimaryColour", new Color(Random.value, Random.value, Random.value, 1f));
		substance.SetProceduralColor("SecondaryColour", new Color(Random.value, Random.value, Random.value, 1f));
		substance.SetProceduralFloat("Heat", (1f-(float)p.p.ice_cover));
		//don't make atmosphere unless needed
		if (p.p.surf_pressure <= 0.0) {
			Destroy(atmos);
		} else {
			atmosphere.SetProceduralFloat("$randomseed", Random.seed);
			atmosphere.SetProceduralFloat ("AtmosphereThickness", (float)p.p.cloud_cover);
			atmosphere.SetProceduralFloat ("Storms", (float)p.p.cloud_cover*(1f-(float)p.p.surf_pressure/1013f));
			atmosphere.RebuildTextures ();
		}	
		substance.RebuildTextures();
		yield return null;
	}

	// Asyncronously builds the texture from the generated planet statistics
	IEnumerator MakeGasGiant(MapPlanetBehaviour p){
		Transform clone = Instantiate(
			GPlanet.transform,
			transform.position,
			transform.rotation) as Transform;
		clone.parent = transform;
		clone.transform.Rotate (Vector3.up, 90f);
		var substance = clone.GetComponent<Renderer>().sharedMaterial as ProceduralMaterial;
		substance.SetProceduralFloat("$randomseed", Random.seed);

		if (p.p.gas_rings) {
			clone.GetChild(0).Rotate(new Vector3(Random.Range(0f, 0.2f),Random.Range(0f, 0.2f), Random.Range(0f, 0.2f)));
		} else {
			Destroy(clone.GetChild(0).gameObject);
		}
		substance.RebuildTextures();
		yield return null;
	}
}
