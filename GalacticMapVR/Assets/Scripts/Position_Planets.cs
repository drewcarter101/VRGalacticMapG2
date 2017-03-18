using UnityEngine;
using System.Collections;

public class Position_Planets : MonoBehaviour {

	public float AU = 1000f;

	public GameObject Mercury;
	public GameObject Venus;
	public GameObject Earth;
	public GameObject Mars;
	public GameObject Jupiter;
	public GameObject Saturn;
	public GameObject Uranus;
	public GameObject Neptune;
	public GameObject Pluto;

	private float MercuryAU = 0.39f;
	private float VenusAU = 0.723f;
	private float EarthAU = 1f;
	private float MarsAU = 1.524f;
	private float JupiterAU = 5.203f;
	private float SaturnAU = 9.538f;
	private float UranusAU = 19.18f;
	private float NeptuneAU = 30.06f;
	private float PlutoAU = 39.53f;


	// Use this for initialization
	void Start () {

		Mercury.transform.position = new Vector3 (Mercury.transform.position.x, Mercury.transform.position.y, MercuryAU * AU);
		Venus.transform.position = new Vector3 (Venus.transform.position.x, Venus.transform.position.y, VenusAU * AU);
		Earth.transform.position = new Vector3 (Earth.transform.position.x, Earth.transform.position.y, EarthAU * AU);
		Mars.transform.position = new Vector3 (Mars.transform.position.x, Mars.transform.position.y, MarsAU * AU);
		Jupiter.transform.position = new Vector3 (Jupiter.transform.position.x, Jupiter.transform.position.y, JupiterAU * AU);
		Saturn.transform.position = new Vector3 (Saturn.transform.position.x, Saturn.transform.position.y, SaturnAU * AU);
		Uranus.transform.position = new Vector3 (Uranus.transform.position.x, Uranus.transform.position.y, UranusAU * AU);
		Neptune.transform.position = new Vector3 (Neptune.transform.position.x, Neptune.transform.position.y, NeptuneAU * AU);
		Pluto.transform.position = new Vector3 (Pluto.transform.position.x, Pluto.transform.position.y, PlutoAU * AU);

	}

}
