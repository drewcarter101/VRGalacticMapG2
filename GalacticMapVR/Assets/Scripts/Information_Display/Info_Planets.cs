using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Planets : MonoBehaviour {

	public GameObject mercuryDisplay;
	public GameObject venusDisplay;
	public GameObject earthDisplay;
	public GameObject marsDisplay;
	public GameObject jupiterDisplay;
	public GameObject saturnDisplay;
	public GameObject uranusDisplay;
	public GameObject neptuneDisplay;
	public GameObject plutoDisplay;

	Dictionary<string, System.Action> displayDict = new Dictionary<string, System.Action>();
	// Use this for initialization
	void Start () {

		displayDict.Add ("Mercury", () => {DisableAllDisplays(); mercuryDisplay.SetActive(true);});
		displayDict.Add ("Venus", () => {DisableAllDisplays(); venusDisplay.SetActive(true);});
		displayDict.Add ("Earth", () => {DisableAllDisplays(); earthDisplay.SetActive(true);});
		displayDict.Add ("Mars", () => {DisableAllDisplays(); marsDisplay.SetActive(true);});
		displayDict.Add ("Jupiter", () => {DisableAllDisplays(); jupiterDisplay.SetActive(true);});
		displayDict.Add ("Saturn", () => {DisableAllDisplays(); saturnDisplay.SetActive(true);});
		displayDict.Add ("Uranus", () => {DisableAllDisplays(); uranusDisplay.SetActive(true);});
		displayDict.Add ("Neptune", () => {DisableAllDisplays(); neptuneDisplay.SetActive(true);});
		displayDict.Add ("Pluto", () => {DisableAllDisplays(); plutoDisplay.SetActive(true);});

	}

	public void ActivatePlanetDisplay(string planet){

		System.Action myAction;

		if (displayDict.TryGetValue (planet, out myAction))
			myAction.Invoke ();

	}

	void DisableAllDisplays(){
		
		mercuryDisplay.SetActive (false);
		venusDisplay.SetActive (false);
		earthDisplay.SetActive (false);
		marsDisplay.SetActive (false);
		jupiterDisplay.SetActive (false);
		saturnDisplay.SetActive (false);
		uranusDisplay.SetActive (false);
		neptuneDisplay.SetActive (false);
		plutoDisplay.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
