using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarGenerator2 : MonoBehaviour {

	public GameObject star;
	public int numStars;
	public int radius;

	// Use this for initialization
	void Start () {
		MakeStars ();
	}

	void MakeStars(){

		for(int i = 0; i<numStars; i++){

			int x = Random.Range(0, radius);
			int y = Random.Range(0, radius);
			int z = Random.Range(0, radius);
			Vector3 newStarPosition = new Vector3 (x,y,z);
			Quaternion quat = new Quaternion (0,0,0,0);

			GameObject newStar = (GameObject)Instantiate (star, newStarPosition, quat, this.transform);

		}

	}

}
