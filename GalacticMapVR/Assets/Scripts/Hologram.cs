using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologram : MonoBehaviour {

	public GameObject starProjection;
	public float captureRadius; //radius of stars to capture
	public LayerMask starMask;

	Collider[] currentStars;

	// Use this for initialization
	void Start () {
		UpdateHologram ();
	}

	public void UpdateHologram(){

		foreach (Transform oldProjection in transform) {
			Destroy (oldProjection.gameObject);
		}

		var stars = Physics.OverlapSphere (transform.position, captureRadius, starMask);
		currentStars = stars;

		foreach (var star in stars) {
			
			Quaternion quat = new Quaternion (0,0,0,0);
			Vector3 pos = (star.transform.position - transform.position) / ((captureRadius * 6));
			pos += transform.position;
			GameObject newStar = (GameObject)Instantiate (starProjection, pos, quat, transform);
			newStar.name = star.name;

		}
			
	}

}
