using UnityEngine;
using System.Collections;

public class CircularOrbit : MonoBehaviour {

	public Transform moveAround;
	public float period;	//year

	private Transform myTransform;
	private Vector3 initialVector;

	void Start () {
		myTransform = transform;
		initialVector = myTransform.position - moveAround.position;
	}

	void Update () {
		myTransform.position = Quaternion.Euler (0, Time.time / period, 0) * initialVector + moveAround.position;
	}
}