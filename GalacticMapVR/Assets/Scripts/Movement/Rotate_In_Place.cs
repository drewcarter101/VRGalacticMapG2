using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_In_Place : MonoBehaviour {

	public float rotationDegreesPerSecond = 45f;
	public float rotationDegrees = 90f;

	private float totalRotation = 0f;

	public void Start(){

		//this.enabled = false;

	}

	public void ButtonPress(){

		this.enabled = true;

	}

	void Rotate(){

		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * rotationDegreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * rotationDegreesPerSecond;

	}

	void Update(){

		if(Mathf.Abs(totalRotation) < Mathf.Abs(rotationDegrees)){

			Rotate();

		} else {

			//reverse direction for next activation
			rotationDegreesPerSecond *= -1f;
			totalRotation = 0f;
			this.enabled = false;

		}

	}

}
