using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlanetSearch : MonoBehaviour {

    public GameObject list;
    public GameObject ListItemPrefab;
    public Text input;
    public GameObject searchView;
    public GameObject mainView;
    public GameObject _camera;
    public GameObject infoDisplay;

    private List<GameObject> prefabs;

	// Use this for initialization
	void Start () {
        prefabs = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onSearchChanged()
    {
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }

        prefabs.Clear();

        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        List<string> matches = new List<string>();

        foreach (GameObject planet in planets)
        {
            string name = planet.GetComponent<ShowInfoFromPlanet>().planetName;

            if (input.text.Length == 0 || name.StartsWith(input.text.ToLower()))
            {
                matches.Add(name);
            }
        }

        foreach(string match in matches)
        {
            GameObject prefab = Instantiate(ListItemPrefab, Vector3.one, Quaternion.identity) as GameObject;

            prefab.transform.SetParent(list.transform, true);
            prefab.GetComponent<Button>().onClick.AddListener(() => selectPlanet(match));

            Text text = prefab.transform.Find("Text").GetComponent<Text>();
            text.text = match;

            prefabs.Add(prefab);
        }
    }

    public void selectPlanet(string name)
    {
        foreach(GameObject planet in GameObject.FindGameObjectsWithTag("Planet"))
        {
            if (name == planet.GetComponent<ShowInfoFromPlanet>().planetName)
            {
                infoDisplay.GetComponent<LeftInfoDisplay>().updateDisplay(planet.GetComponent<ShowInfoFromPlanet>());
                searchView.SetActive(false);
                _camera.transform.LookAt(infoDisplay.transform);
                break;
            }
        }
    }
}
