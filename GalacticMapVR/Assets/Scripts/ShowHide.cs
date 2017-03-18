using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour {

    private GameObject gameMenuHome;

    private GameObject gameMenuSettings;

    private GameObject arrow1;
    private GameObject arrow2;
    private GameObject arrow3;

    private GameObject cam;


	// Use this for initialization
	void Start () {
    
        gameMenuHome = transform.FindChild("GameMenuHome").gameObject;

        gameMenuSettings = transform.FindChild("GameMenuSettings").gameObject;

        cam = GameObject.Find("Main Camera");

        gameMenuHome.SetActive(false);
        gameMenuSettings.SetActive(false);

        


    }
	
	// Update is called once per frame
	void Update () {

        if(gameMenuHome.activeSelf || gameMenuSettings.activeSelf)
        {
            cam.GetComponent<GhostFreeRoamCamera>().allowMovement = false;
            cam.GetComponent<GhostFreeRoamCamera>().allowRotation = false;
        } else
        {

            cam.GetComponent<GhostFreeRoamCamera>().allowMovement = true;
            cam.GetComponent<GhostFreeRoamCamera>().allowRotation = true;

        }

 
	}


    public void toggleHome()
    {

        gameMenuHome.SetActive(!gameMenuHome.activeSelf);
        gameMenuSettings.SetActive(false);
    
    }
    public void toggleSettings()
    {

        gameMenuHome.SetActive(false);
        gameMenuSettings.SetActive(true);
    


    }
}
