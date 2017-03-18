using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Generate_Stars : MonoBehaviour {

	private int starCount = 0;

	public float maxLightYearRadius = 10; //Max radius for stars to spawn
	public float maxMagnitude = 5;
	public float starDistanceScale;

	private float magnitudeModifier = 1f;

	public GameObject Star_Class_O;
	public GameObject Star_Class_A;
	public GameObject Star_Class_B;
	public GameObject Star_Class_F;
	public GameObject Star_Class_G;
	public GameObject Star_Class_K;
	public GameObject Star_Class_M;

	public HIPPARCOS_Data data;
	public Transform starSpace;
	public Transform spawner; //The transform used to spawn the stars

	Dictionary<string, GameObject> starClasses = new Dictionary<string, GameObject>();

	public float sizeModifier;

	// Use this for initialization
	void Awake () {

		starClasses.Add ("O", Star_Class_O);
		starClasses.Add ("A", Star_Class_A);
		starClasses.Add ("B", Star_Class_B);
		starClasses.Add ("F", Star_Class_F);
		starClasses.Add ("G", Star_Class_G);
		starClasses.Add ("K", Star_Class_K);
		starClasses.Add ("M", Star_Class_M);

		SpawnStars ();


	}

	string GetStarClass(string exp){

		string pattern = @"([A-Z]).*";
		string result = Regex.Match (exp, pattern).Groups[1].Value;
		return result;

	}

	void SpawnStars(){

		var allData = data.GetAllData ();

		foreach(var row in allData){

			if (row.dist == "100000" || row.hd == "" || (float.Parse(row.dist))*3.26156f > maxLightYearRadius || (float.Parse(row.mag)) > maxMagnitude)
				continue;

			//Vector3 pos = new Vector3 (Random.Range (-maxSpawnRadius, maxSpawnRadius), Random.Range (-maxSpawnRadius, maxSpawnRadius), Random.Range (-maxSpawnRadius, maxSpawnRadius));
			//spawner.transform.eulerAngles = new Vector3(float.Parse(row.bii), float.Parse(row.lii), 0f);
			//Vector3 pos = spawner.transform.forward * float.Parse(row.dist) * 100;
			Vector3 pos = new Vector3(float.Parse(row.x), float.Parse(row.y), float.Parse(row.z)) * starDistanceScale;
			Quaternion quat = new Quaternion (0,0,0,0);
			GameObject starClass;
			starClasses.TryGetValue(GetStarClass (row.spect), out starClass);
			//if(starClass == null)
				starClass = Star_Class_F;
			GameObject newStar = (GameObject)Instantiate (starClass, pos, quat, starSpace);
			float scale = magnitudeModifier; //;Math.Abs(magnitudeModifier * (1 / float.Parse(row.absmag)));
			if (scale > 10)
				scale = 10f;
			newStar.transform.localScale = new Vector3 (scale, scale, scale);

			if (row.proper == "")
				newStar.name = row.hd;
			else
				newStar.name = row.proper;

			starCount++;
		}

		print ("There are " + starCount + " stars");

	}

	// Update is called once per frame
}
