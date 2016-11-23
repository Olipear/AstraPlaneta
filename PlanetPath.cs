using UnityEngine;
using System.Collections;

// class to draw the lines on the nav deck
public class PlanetPath : MonoBehaviour {

	private LineRenderer line;
	private int segments = 60;


	void  Awake(){
		line = gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount (segments + 1);
	}
	
	public void drawOrbit (float xrad, float yrad, float zrad)
	{	
		float x;
		float z;
		float angle = 20f;
		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xrad;
			z = Mathf.Cos (Mathf.Deg2Rad * angle) * zrad;
			line.SetPosition (i,new Vector3(x,yrad,z) );
			angle += (360f / segments);
		}
	}

}
