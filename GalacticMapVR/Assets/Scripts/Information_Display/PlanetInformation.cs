using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetInformation : MonoBehaviour {

	private Dictionary<string, string> Planets = new Dictionary<string, string>(); //Dictionary of Planet information

	// Use this for initialization
	void Start () {

		//Adding random information for each planet

		Planets.Add("mercury", "Mercury is the smallest planet in our solar system.");

		Planets.Add ("venus", "were a baseball, Mercury would " +
								"be a golf ball");

		Planets.Add ("earth", "Earth has people on it");

		Planets.Add ("mars", "Mars is really red");

		Planets.Add ("jupiter", "Jupiter is very big");

		Planets.Add ("saturn", "Saturn has rings");

		Planets.Add ("uranus", "Uranus is nice");

		Planets.Add ("neptune", "Neptune is nicer");

		Planets.Add ("pluto", "Pluto is sad");
		
	}

	//search method, to search for a given planet andreturn itś information
	public string search(string input){


		if (Planets.ContainsKey (input)) {
            Debug.Log("Input is: " + input);
            string outway = Planets [input];
			return outway; 
		} else {
			//returns this incase user searches for a star since this is for planets
			return "star";
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
