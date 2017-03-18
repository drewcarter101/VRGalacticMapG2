using UnityEngine;
using System.Collections;

public class RingEffect : MonoBehaviour {

	public Material ringMaterial;
	private Transform myTranform;
	public Transform sunTransform;

	void Awake () {
		myTranform = transform;
	}
	
	void Update () {
		Vector3 lightDir = myTranform.position - sunTransform.position;
		Vector3 newLightDir = new Vector3 (lightDir.x, 0, lightDir.z);

		Vector3 dir = Vector3.Cross (Vector3.forward, newLightDir);
		float angle;
		if (dir.y >= 0)
		{
			angle = (Vector3.Angle (Vector3.forward, newLightDir) - myTranform.rotation.eulerAngles.y) / 360;
		}
		else
		{
			angle = (- Vector3.Angle (Vector3.forward, newLightDir) - myTranform.rotation.eulerAngles.y) / 360;
		}

		ringMaterial.SetVector ("_Light", new Vector4 (lightDir.x, lightDir.y, lightDir.z, angle));
	}
}