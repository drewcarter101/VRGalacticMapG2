using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfoFromPlanet : MonoBehaviour {

    public string planetName;
    public string planetDescription;
    public double planetRadius;
    public double planetDensity;
    public double lengthOfDay;
    public double lengthOfYear;
    public double surfaceTemperature;

    private GameObject infoDisplay;

    public void updateInformationDisplay() {

        infoDisplay.GetComponent<LeftInfoDisplay>().updateDisplay(this);
    }

	// Use this for initialization
	void Start () {

        infoDisplay = GameObject.Find("LeftDisplay");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
