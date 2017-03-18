using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Test : MonoBehaviour {

	public Info_Planets infoPlanets;
	// Use this for initialization
	void Start () {
		
	}

	void TestFunction1(){

		infoPlanets.ActivatePlanetDisplay ("Saturn");

	}

	void TestFunction2(){

		infoPlanets.ActivatePlanetDisplay ("Earth");

	}

	void Update(){
		if (Input.GetMouseButtonDown (0))
			TestFunction1 ();
		if (Input.GetMouseButton (1))
			TestFunction2 ();
	}
}
