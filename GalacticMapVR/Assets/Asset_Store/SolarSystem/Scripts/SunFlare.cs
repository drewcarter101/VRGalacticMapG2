using UnityEngine;
using System.Collections;

public class SunFlare : MonoBehaviour {

	public Transform cameraTransform;

	void Update () {
		float dis = (cameraTransform.position - transform.position).magnitude;
		float scale = Mathf.Sqrt(dis / 5);
		transform.localScale = new Vector3(scale, scale, scale);
		transform.LookAt (cameraTransform, cameraTransform.up);
	}
}
