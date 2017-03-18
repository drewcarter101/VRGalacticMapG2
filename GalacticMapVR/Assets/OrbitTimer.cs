using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTimer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {

        int timer = 1000;

        while(timer > 0)
        {
            timer--;
        }
        if(timer == 0)
        {
            transform.GetComponent<TrailRenderer>().time = -1;
            transform.GetComponent<TrailRenderer>().time = Mathf.Infinity;
        }
		
	}


}
