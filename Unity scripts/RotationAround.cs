using UnityEngine;
using System.Collections;

public class RotationAround : MonoBehaviour {
	public GameObject ParentRotation;
	public float speed;
	public Vector3 axis;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (ParentRotation.transform.position, axis, speed * Time.deltaTime);
	}
}
