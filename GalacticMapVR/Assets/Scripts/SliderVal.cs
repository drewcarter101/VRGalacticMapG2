using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVal : MonoBehaviour {

    public GameObject cam;

    public string setting;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(setting == "fieldOfView")
        {
            gameObject.GetComponent<Text>().text = "" + cam.GetComponent<Camera>().fieldOfView;
        }
        if (setting == "farClipPlane")
        {
            gameObject.GetComponent<Text>().text = "" + cam.GetComponent<Camera>().farClipPlane;
        }
        if (setting == "masterVolume")
        {
            gameObject.GetComponent<Text>().text = "" + cam.GetComponent<AudioSource>().volume;
        }

    }
}
