using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Player : MonoBehaviour {

	public Transform root;
	public Transform home;
	public Transform stars;

	Lerp_pos lerpPos;
	SpeechRecognition speechListener;
	public Hologram hologram;
	public LayerMask starMask;

	private float TransportSpeed = 20f;
	Transform nearestStar;
	// Use this for initialization
	void Start () {

		nearestStar = root;
		lerpPos = gameObject.AddComponent<Lerp_pos> ();
		lerpPos.MovementEnd += UpdateHologram;
	}

	void UpdateHologram(){
		
		hologram.UpdateHologram ();

	}

	Collider[] GetNearbyStars(float captureRadius){
		
		var stars = Physics.OverlapSphere (root.position, captureRadius, starMask);

		if (stars.Length <=1)
			stars = GetNearbyStars (captureRadius + 10f);
		
		return stars;

	}

	void GoToRandomStar(){
		
		float captureRadius = 1000f;
		var stars = GetNearbyStars (captureRadius);

		var star = MyRandom.GetRandomPrefab (stars);
		lerpPos.MoveTo (root, star.transform.position, TransportSpeed);
		nearestStar = star.transform;

	}

	void GoToNearestStar(){
		
		float captureRadius = 10f;
		float minDistance = 1000f;
		Transform tempStar = nearestStar;

		Collider[] stars = GetNearbyStars (captureRadius);

		foreach(Collider star in stars){

			if (star.name == tempStar.name)
				continue;
			
			if(Vector3.Distance(star.transform.position, root.position) < minDistance){
				minDistance = Vector3.Distance (star.transform.position, root.position);
				nearestStar = star.gameObject.transform;
			}
		}
			
		if (nearestStar != root) {
			lerpPos.MoveTo (root, nearestStar.position, TransportSpeed);
		}

	}

	void GoBackHome(){
		lerpPos.MoveTo (root, home.position, TransportSpeed);
	}

	void MoveToStar(string hitName){
		string starDestination = hitName;

		foreach(Transform star in stars){
			if (starDestination == star.name)
				lerpPos.MoveTo (root, star.position, TransportSpeed);
		}
	}

	void ClickMenuButton(RaycastHit hit){

		print ("Click menu button");

		Button button = hit.collider.GetComponent<Button> ();
		if (button == null)
			return;

		button.onClick.Invoke ();

	}

	void RayCastFire(){
						
		RaycastHit hit;

		if(Physics.Raycast(transform.position,transform.forward, out hit)){

            if (hit.collider.CompareTag("StarProjection"))
                MoveToStar(hit.collider.name);
            else if (hit.collider.CompareTag("Menu_Button"))
                ClickMenuButton(hit);
            else if (hit.collider.CompareTag("MoveToSol"))
                GoBackHome();
            else if (hit.collider.CompareTag("Planet"))
                hit.collider.GetComponent<ShowInfoFromPlanet>().updateInformationDisplay();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
			RayCastFire ();
		else if (Input.GetMouseButtonDown (1))
			GoBackHome ();
	}
}
