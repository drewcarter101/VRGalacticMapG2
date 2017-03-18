using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAL : MonoBehaviour {

	public Renderer halsEye;
	public Color halsEyeActivated;
	public Color halsEyeDeactivated;
	private Color currentEyeColor;
	private Color targetEyeColor;
	private Material halsEyeMat;
	private bool halIsActive;

	public AudioClip turnOn;
	public AudioClip turnOff;
	public AudioClip commandIssued;
	public AudioClip sorry;

	private AudioSource audioSource;
	private SpeechRecognition speechRecognition;

	// Use this for initialization
	void Start () {

		currentEyeColor = halsEyeDeactivated;
		halsEyeMat = halsEye.material;
		halsEyeMat.color = currentEyeColor;
		speechRecognition = FindObjectOfType<SpeechRecognition> ();
		if (speechRecognition == null)
			print ("ERROR: Could not find SpeechRecognition!");
		audioSource = GetComponent<AudioSource> ();

		speechRecognition.CommandSuccessful += HalCommand;
		speechRecognition.halActivated += HalActivated;
		speechRecognition.halDeactivated += HalDeactivated;
		speechRecognition.CantDoThat += CantDoThat;

		this.enabled = false;
	}

	void CantDoThat(){
		
		audioSource.clip = sorry;
		audioSource.Play ();

	}

	void PowerHalsEye(){
		if (currentEyeColor == halsEyeActivated) {
			targetEyeColor = halsEyeDeactivated;
		} else {
			targetEyeColor = halsEyeActivated;
		}
		this.enabled = true;
	}

	void HalCommand(){
		
		audioSource.clip = commandIssued;
		audioSource.Play ();

	}

	void HalActivated(){
		audioSource.clip = turnOn;
		audioSource.Play ();

		if (halIsActive)
			return;
		PowerHalsEye ();
		halIsActive = true;
	}

	void HalDeactivated(){
		PowerHalsEye ();
		audioSource.clip = turnOff;
		audioSource.Play ();
		halIsActive = false;
	}

	void Update(){
		currentEyeColor = Color.Lerp (currentEyeColor, targetEyeColor, Time.time);
		halsEyeMat.color = currentEyeColor;
		if (currentEyeColor.r - targetEyeColor.r < 0.1f) {
			currentEyeColor = targetEyeColor;
			halsEyeMat.color = currentEyeColor;
			this.enabled = false;
		}
	}
}
