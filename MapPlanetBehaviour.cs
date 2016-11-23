using UnityEngine;
using System.Collections;

// script for the planets on the nav map
public class MapPlanetBehaviour : MonoBehaviour {
	
	public Planet p;
	public Vector3 parentpos;
	public bool explored;
	public string descriptionShort;
	public string descriptionLong;
	public string descriptionExplored;
	private Material substance;
	private Color normalColour;

	// make all the text needed for the screen displays
	public void generateDisText(){
		if (p != null) {
			explored = false;
			string planetType;
			if (p.gas_giant == true) {
					planetType = "Gas Giant";
			} else {
					planetType = "RockyPlanet";
			}
			descriptionShort = planetType + ". Orbiting at " + p.a.ToString("F2") + " AU";
			if (!p.gas_giant){
				descriptionShort = "Gravity:" + p.surf_grav.ToString("F2") + " G's";
			}
			descriptionLong = descriptionShort +
				" \n Est. age:" + (p.age/1000000).ToString("F2") + " million years";
			if (p.surf_temp > 1000.0){
				descriptionLong += "\n Insanely hot over 1000 Kelvin";
			}else if (!p.gas_giant){descriptionLong +=" \n Surfae Temp:"+p.surf_temp.ToString("F2")+" Kelvin";}
			descriptionLong +=	" \n Surface Pressure:" + p.surf_pressure + " millibars"+
				" \n Day length: "+p.day.ToString("F2")+" Hours";
			if (p.surf_pressure > 0.0 || !p.gas_giant){
				descriptionLong = descriptionLong + " \n Atmosphere O2[" + p.GO2.ToString("F2") + "%] " + "N2[" + p.GN2.ToString("F2") + "%] " + "CO2[" + p.GCO2.ToString("F2") + "%]";
			}
		}
	}

	// depending on input will highlight the planet in a certain colour
	public void highlight (int i){
		switch (i) {
			//unselected
			case 0: 
				substance.color = normalColour;
				break;
			//current
			case 1: 
				substance.color = Color.green;				
				break;
			// visited
			case 2: 
				substance.color = Color.yellow;
				break;
			// destination
			case 3: 
				substance.color = Color.blue;				
				break;
		}
	}

	// remember the start colour get the material
	void Awake () {
		substance = GetComponent<Renderer>().material as Material;
		normalColour = substance.color;
	}

	// go round the star, speed depends on orbital period
	// Update is called once per frame
	void Update () {
		transform.RotateAround(parentpos, Vector3.up, (1500f/(float)p.orb_period) * Time.deltaTime);
	}
}
