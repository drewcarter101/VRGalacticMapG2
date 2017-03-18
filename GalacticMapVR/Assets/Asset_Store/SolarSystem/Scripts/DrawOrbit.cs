using UnityEngine;
using System.Collections;

public class DrawOrbit : MonoBehaviour
{

    public Transform moveAround;
    public float speed;    //year

    private Transform myTransform;
    private Vector3 initialVector;

    void Start()
    {
        myTransform = transform;
        initialVector = myTransform.position - moveAround.position;
    }

    void Update()
    {

        myTransform.position = Quaternion.Euler(0, Time.time / speed, 0) * initialVector + moveAround.position;

    
    }
}