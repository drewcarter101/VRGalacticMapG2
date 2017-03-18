using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public string sceneName;

	// Use this for initialization
	void Start () {
		sceneName = "GalacticMapOrbitsAndMenu";
	}


	public void StartGame() {
		SceneManager.LoadSceneAsync (sceneName);
	}

	public void Exit() {
		Debug.Log ("Application Quit");
		Application.Quit();
	}
}
