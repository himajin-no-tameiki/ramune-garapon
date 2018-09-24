using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleController : MonoBehaviour {

	public GameObject objectToRotate;
	public GameObject rotateCenter;
	public float rotateSpeed = 40f;

	private Quaternion startRotation;
	private bool mouseDown;
	private Camera cam;
	
	// Use this for initialization
	void Start () {
		startRotation = objectToRotate.transform.localRotation;
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {

	}


}
