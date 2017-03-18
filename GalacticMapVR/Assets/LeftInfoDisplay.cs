using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftInfoDisplay : MonoBehaviour {

    private Text _name;
    private Text radius;
    private Text density;
    private Text day;
    private Text year;
    private Text temperature;
    private Text description;
    private RawImage image;

    public void updateDisplay(ShowInfoFromPlanet planet) {

        _name.text = planet.planetName;
        radius.text = planet.planetRadius.ToString() + " M";
        density.text = planet.planetDensity.ToString() + " kg/m3";
        day.text = planet.lengthOfDay.ToString();
        year.text = planet.lengthOfYear.ToString();
        temperature.text = planet.surfaceTemperature.ToString() + " K";
        description.text = planet.planetDescription;

        StartCoroutine(setPlanetImage(string.Format("http://solarsystem.nasa.gov/images/planets/galpic_{0}.png", planet.planetName)));
    }

    public IEnumerator setPlanetImage(string url) {

        WWW www = new WWW(url);
        yield return www;

        image.texture = www.texture;
    }

	// Use this for initialization
	void Start () {

        _name = transform.Find("PlanetName").GetComponent<Text>();
        radius = transform.Find("PlanetRadius").GetComponent<Text>();
        density = transform.Find("PlanetDensity").GetComponent<Text>();
        day = transform.Find("PlanetLengthDay").GetComponent<Text>();
        year = transform.Find("PlanetLengthYear").GetComponent<Text>();
        temperature = transform.Find("PlanetTemperature").GetComponent<Text>();
        description = transform.Find("PlanetDescription").GetComponent<Text>();
        image = transform.Find("PlanetImage").GetComponent<RawImage>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
