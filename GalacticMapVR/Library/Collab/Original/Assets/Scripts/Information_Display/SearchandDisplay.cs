using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchandDisplay : MonoBehaviour {


	private string output;
	public InputField input; 
	public Text outpanel;
	public Text title;
	public Text minitopInfo;
	public Image display;
	public Sprite mercury;
	public Sprite venus;
	public Sprite earth;
	public Sprite mars;
	public Sprite jupiter;
	public Sprite saturn;
	public Sprite uranus;
	public Sprite neptune;
	public Sprite pluto;
	PlanetInformation planet;

	private Dictionary<string, Sprite> PlanetImage = new Dictionary<string, Sprite>();

	// Use this for initialization
	void Start () {

		PlanetImage.Add("mercury", mercury);

		PlanetImage.Add ("venus", venus);

		PlanetImage.Add ("earth", earth);

		PlanetImage.Add ("mars", mars);

		PlanetImage.Add ("jupiter", jupiter);

		PlanetImage.Add ("saturn", saturn);

		PlanetImage.Add ("uranus", uranus);

		PlanetImage.Add ("neptune", neptune);

		PlanetImage.Add ("pluto", pluto);

		planet = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlanetInformation>();

	}

	// Update is called once per frame
	void Update () {

		if(input.text != "" && Input.GetKey(KeyCode.Return)) {
			output = planet.search(input.text);

			//check if output isn star
			if(!(output.Equals("star"))){
				outpanel.text = output;
				minitopInfo.text = output;
				title.text = input.text;
				display.sprite = PlanetImage[input.text];
			}//else, search star database
			input.text = "";
		}
	}
}
