using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaraponController : MonoBehaviour {
	public GameObject rotateCenter;
	public float rotateSpeedMultplier = 1f;
	public float maxRotateSpeed = 40f;

	private Quaternion startRotation;
	private bool mouseDown;
	private Camera cam;
	private float angle = 0f;
	private Rigidbody rb;

	void Start () {
		startRotation = transform.rotation;
		startRotation = transform.localRotation;
		cam = Camera.main;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {	
		if (mouseDown) {
			var mouse = Input.mousePosition;
			var rotateCenterPosition = cam.WorldToScreenPoint(rotateCenter.transform.position);
			var delta = mouse - rotateCenterPosition;
			var targetAngle = Mathf.Atan2(delta.x, delta.y) * Mathf.Rad2Deg;

			var maxAngleDelta = Mathf.Min(rotateSpeedMultplier * Time.deltaTime, maxRotateSpeed * Time.deltaTime);
			var nextAngle = Mathf.LerpAngle(angle, targetAngle, maxAngleDelta);

			var nextRotation = Quaternion.AngleAxis(nextAngle, Vector3.forward) * startRotation;
			rb.MoveRotation(nextRotation);

			angle = nextAngle;
		}
	}

	void OnMouseDown() {
		mouseDown = true;
		Debug.Log("down");
  }

	void OnMouseUp() {
		mouseDown = false;
		Debug.Log("up");
	}
}
