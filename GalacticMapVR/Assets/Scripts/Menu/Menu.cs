using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public GameObject Menu_Home;
	public GameObject Menu_Hal;

	public void EnableMenuHome(){
		DisableAllMenus ();
		Menu_Home.SetActive (true);
	}
		
	public void EnableMenuHal(){
		DisableAllMenus ();
		Menu_Hal.SetActive (true);
	}

	void DisableAllMenus(){
		
		Menu_Home.SetActive (false);
		Menu_Hal.SetActive (false);

	}

}
