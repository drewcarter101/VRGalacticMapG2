using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rotationSpeed = 10f; 
	public bool rotateLeft;
	public bool rotateRight;

	private float dir;

	void Start(){
		if (rotateLeft)
			dir = 1;
		else
			dir = -1;
	}

	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.up * Time.deltaTime * dir * rotationSpeed);
	}
}
