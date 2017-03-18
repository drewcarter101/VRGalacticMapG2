using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lerp_pos : MonoBehaviour {

	private float startTime; // time at start of the move
	private float journeyLength; // distance between origin position and destination
	private Vector3 destination; 
	private Transform originTransform;
	private float speed;

	private bool isInMotion; //whether this script is moving the transform
	public Action MovementStart;
	public Action MovementEnd;
	public Action MovementInMotion;

	void Awake(){

		this.enabled = false;

	}

	public void MoveTo(Transform originTransform, Vector3 destination, float speed){

		if (isInMotion || originTransform == null)
			return;
		
		this.enabled = true;
		this.speed = speed;
		this.originTransform = originTransform;
		isInMotion = true;
		this.destination = destination;
		startTime = Time.time;
		journeyLength = Vector3.Distance (originTransform.position, destination);
		startTime = Time.time;

		if(MovementStart != null)
			MovementStart ();

	}
	
	// Update is called once per frame
	void Update () {

		if (MovementInMotion != null)
			MovementInMotion ();

		float distCovered = (Time.time - startTime) * speed;
		float fractJourney = distCovered / journeyLength;

		originTransform.position = Vector3.Lerp (originTransform.position, destination, fractJourney);

		if (Vector3.Distance (originTransform.position, destination) < 0.1f) {

			destination = Vector3.zero;
			isInMotion = false;

			if(MovementEnd != null)
				MovementEnd ();
			
			this.enabled = false;

		}

	}

}
