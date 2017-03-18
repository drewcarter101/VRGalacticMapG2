using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRandom : MonoBehaviour {

	public static GameObject GetRandomPrefab(GameObject[] prefabs){
		
		int max = prefabs.Length - 1;
		int rand = Random.Range (0, max);
		return prefabs[rand];

	}

	public static Collider GetRandomPrefab(Collider[] prefabs){

		int max = prefabs.Length - 1;
		int rand = Random.Range (0, max);
		return prefabs[rand];

	}


}
