using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour {

	public GameObject menu;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void toggle()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
