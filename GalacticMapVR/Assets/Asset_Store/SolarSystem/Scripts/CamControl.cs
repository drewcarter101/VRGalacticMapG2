using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {
	
	public float moveSpeed;
	public float rotateSpeed;
	public Transform follow;
	private Transform myTransform;
	private Vector3 followDir;

	void Awake () {
		myTransform = transform;
		followDir = Vector3.forward * 5;
	}

	void LateUpdate () {
		FollowPlanet ();
		myTransform.Rotate (0, 0, Input.GetAxis ("Mouse ScrollWheel") * rotateSpeed * 5);
		if (Input.GetMouseButton (0))
		{
			myTransform.Rotate (Input.GetAxis ("Mouse Y") * rotateSpeed, -Input.GetAxis ("Mouse X") * rotateSpeed, 0);
		}

		if (follow)
		{
			followDir += moveSpeed * Time.deltaTime * (myTransform.forward * Input.GetAxis ("Vertical") + myTransform.right * Input.GetAxis ("Horizontal"));
			myTransform.position = follow.position + followDir;
		}
		else
		{
			myTransform.position += moveSpeed * Time.deltaTime * (myTransform.forward * Input.GetAxis ("Vertical") + myTransform.right * Input.GetAxis ("Horizontal"));
		}
	}

	void FollowPlanet () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			follow = GameObject.Find ("Mercury").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			follow = GameObject.Find ("Venus").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			follow = GameObject.Find ("Earth").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			follow = GameObject.Find ("Mars").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			follow = GameObject.Find ("Jupiter").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			follow = GameObject.Find ("Saturn").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			follow = GameObject.Find ("Uranus").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			follow = GameObject.Find ("Neptune").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
			follow = GameObject.Find ("Pluto").transform;
			Follow ();
		} else if (Input.GetKeyDown (KeyCode.Alpha0)) {
			follow = null;
		}
	}

	void Follow () {
		followDir = - Vector3.forward * follow.localScale.x * 2;
		myTransform.position = follow.position + followDir;
		myTransform.LookAt (follow.position);
	}
	
}