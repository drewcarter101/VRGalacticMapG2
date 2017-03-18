using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_To : MonoBehaviour {

    public Transform target;
    public float speed;
    public float buffer_distance;
    public bool jumpTo;
	
	// Update is called once per frame
	void Update () {

        if (jumpTo)
        {

            
            float dist = Vector3.Distance(transform.position, target.position);
            float step = speed * Time.deltaTime;

            if (dist > buffer_distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            }
            if (dist > buffer_distance)
            {
                

            }




        }



    }
    public void JumpTo(Transform newTarget)
    {
        target = newTarget;
        jumpTo = true;
    }
}
