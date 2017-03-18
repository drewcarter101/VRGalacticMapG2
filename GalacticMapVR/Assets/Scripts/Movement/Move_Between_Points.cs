using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Between_Points : MonoBehaviour {

	public float delta_y;
	public float delta_x;
	public float delta_z;

	public float waitAtPoint;

	public float speed;

	public Vector3 destination;
	private float startTime;

	private float journeyLength;
	private bool ableToMove;

	private Vector3 originPosition;
	private Vector3 destPosition;

	void Start(){

		originPosition = transform.position;
		destPosition = transform.position + new Vector3 (delta_x, delta_y, delta_z);

		ableToMove = true;
		startTime = Time.time;
		journeyLength = Vector3.Distance (originPosition, destPosition);
		destination = destPosition;

	}
		
	IEnumerator Wait(Vector3 dest){

		ableToMove = false;
		yield return new WaitForSeconds (waitAtPoint);
		destination = dest;
		startTime = Time.time;
		ableToMove = true;

	}
	
	// Update is called once per frame
	void Update () {

		if(!ableToMove){
			
			return;

		}

		float distCovered = (Time.time - startTime) * speed;
		float fractJourney = distCovered / journeyLength;

		transform.position = Vector3.Lerp (transform.position, destination, fractJourney);

		if(Vector3.Distance(transform.position, destination) < 0.001f){
			
			if(destination == originPosition){

				transform.position = originPosition;
				StartCoroutine(Wait(destPosition));

			} else {

				transform.position = destPosition;
				StartCoroutine(Wait(originPosition));

			}

		}

	}

}
