using UnityEngine;
using System.Collections;

// for other cameras, just makes the field of view the same as main camera (no longer used)
public class SkyBoxCamera : MonoBehaviour {
	private Camera cam;
	// Use this for initialization
	void Start()
	{
		cam = this.GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
		
		cam.fieldOfView = Camera.main.fieldOfView+20f;
	}
}
