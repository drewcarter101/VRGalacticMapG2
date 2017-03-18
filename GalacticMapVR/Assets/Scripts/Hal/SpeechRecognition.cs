using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class SpeechRecognition : MonoBehaviour {

	DictationRecognizer dictationRecognizer;
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	string speechInput;

	public Action halActivated;
	public Action halDeactivated;
	public Action CommandSuccessful; //called when a speech command is issued and HAL understands it
	public Action CantDoThat; 

	public Action goHome;
	public Action goToNearestStar;
	public Action goToRandomStar;

	private bool halListening;
	private float halTimeout = 30f;
	private float issueCommandTimer = 0.5f;

	void Start(){

		GoHomeSpeechInputs ();
		GoToNearestStarInputs ();
		GoToRandomStarInputs ();
		GoToNearestPlanetInputs ();
		CantDoThatInputs ();
		HalInputs ();

		keywordRecognizer = new KeywordRecognizer (keywords.Keys.ToArray());
		dictationRecognizer = new DictationRecognizer();
		dictationRecognizer.DictationResult += TestRawOutput;
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognized;
		keywordRecognizer.Start ();

	}

	void KeywordRecognizerOnPhraseRecognized(PhraseRecognizedEventArgs args){

		System.Action keywordAction;

		if (keywords.TryGetValue (args.text, out keywordAction)) {
			speechInput = args.text;
			if(halListening){
				CommandSuccessfulAction ();
				StartCoroutine (IssueCommand(keywordAction));
			} else {
				string pattern1 = @".*(hal).*";
				string pattern2 = @".*(how).*";
				string pattern3 = @".*(help).*";
				string result1 = Regex.Match (speechInput, pattern1).Groups[1].Value;
				string result2 = Regex.Match (speechInput, pattern2).Groups[1].Value;
				string result3 = Regex.Match (speechInput, pattern3).Groups[1].Value;
				if (result1 == "hal" || result2 == "how" || result3 == "help")
					HalActivatedAction ();
			}
		}
	}

	IEnumerator IssueCommand(Action keywordAction){
		yield return new WaitForSeconds (issueCommandTimer);
		keywordAction.Invoke ();
		StopAllCoroutines ();
		StartCoroutine (HalListeningTimer());
	}

	IEnumerator HalListeningTimer (){
		yield return new WaitForSeconds (halTimeout);
		HalDeactivatedAction ();
	}

	void CommandSuccessfulAction(){
		if(CommandSuccessful != null){
			CommandSuccessful ();
		}
	}

	void CantDoThatInputs(){
		
		keywords.Add ("hal destroy the earth", () => CantDoThatAction());
		keywords.Add ("make me a cake", () => CantDoThatAction());
		keywords.Add ("hal make me a cake", () => CantDoThatAction());
		keywords.Add ("hal kill me", () => CantDoThatAction());
		keywords.Add ("hal destroy the galaxy", () => CantDoThatAction());

	}

	void HalInputs(){
		keywords.Add ("help", () => HalActivatedAction());

		keywords.Add ("how", () => HalActivatedAction());
		keywords.Add ("hello how", () => HalActivatedAction());
		keywords.Add ("hi how", () => HalActivatedAction());
		keywords.Add ("how wake up", () => HalActivatedAction());
		keywords.Add ("wake up how", () => HalActivatedAction());

		keywords.Add ("hal", () => HalActivatedAction());
		keywords.Add ("hello hal", () => HalActivatedAction());
		keywords.Add ("hi hal", () => HalActivatedAction());
		keywords.Add ("hal wake up", () => HalActivatedAction());
		keywords.Add ("wake up hal", () => HalActivatedAction());

		//--------------------------------------------------------
		keywords.Add ("goodbye", () => HalDeactivatedAction());
		keywords.Add ("hal turn off", () => HalDeactivatedAction());
		keywords.Add ("hal shut up", () => HalDeactivatedAction());


	}

	void CantDoThatAction(){
		if (CantDoThat != null)
			CantDoThat ();
	}

	void HalActivatedAction(){
		StopAllCoroutines ();
		print ("Hal activated");
		if (halActivated != null)
			halActivated ();
		halListening = true;
		StartCoroutine (HalListeningTimer());
	}

	void HalDeactivatedAction(){
		StopAllCoroutines ();
		print ("Hal deactivated");
		if (halDeactivated != null)
			halDeactivated ();
		halListening = false;
	}

	void GoToNearestPlanetInputs(){
		keywords.Add ("move to closest planet", () => GoToNearestPlanet());
		keywords.Add ("move to nearest planet", () => GoToNearestPlanet());
		keywords.Add ("move to nearest climate", () => GoToNearestPlanet());
		keywords.Add ("hal move to closest planet", () => GoToNearestPlanet());
		keywords.Add ("hal move to nearest planet", () => GoToNearestPlanet());
		keywords.Add ("hal move to nearest climate", () => GoToNearestPlanet());

		keywords.Add ("go to closest planet", () => GoToNearestPlanet());
		keywords.Add ("go to nearest planet", () => GoToNearestPlanet());
		keywords.Add ("go to nearest climate", () => GoToNearestPlanet());
	}

	void GoToRandomStarInputs(){
		keywords.Add ("take me to a random star", () => GoToRandomStar());
		keywords.Add ("take me to random star", () => GoToRandomStar());

		keywords.Add ("go to a random star", () => GoToRandomStar());
		keywords.Add ("go to random star", () => GoToRandomStar());

		keywords.Add ("move to a random star", () => GoToRandomStar());
		keywords.Add ("move to random star", () => GoToRandomStar());

		keywords.Add ("hal take me to a random star", () => GoToRandomStar());
		keywords.Add ("hal take me to random star", () => GoToRandomStar());

		keywords.Add ("hal go to a random star", () => GoToRandomStar());
		keywords.Add ("hal go to random star", () => GoToRandomStar());

		keywords.Add ("hal move to a random star", () => GoToRandomStar());
		keywords.Add ("hal move to random star", () => GoToRandomStar());
	}

	void GoToNearestStarInputs(){
		keywords.Add ("take me to the closest star", () => GoToNearestStar());
		keywords.Add ("take me to the nearest star", () => GoToNearestStar());
		keywords.Add ("take me to a near star", () => GoToNearestStar());

		keywords.Add ("move to closest star", () => GoToNearestStar());
		keywords.Add ("move to nearest star", () => GoToNearestStar());
		keywords.Add ("move to near star", () => GoToNearestStar());

		keywords.Add ("go to closest star", () => GoToNearestStar());
		keywords.Add ("go to nearest star", () => GoToNearestStar());
		keywords.Add ("go to near star", () => GoToNearestStar());

		keywords.Add ("go to the closest star", () => GoToNearestStar());
		keywords.Add ("go to the nearest star", () => GoToNearestStar());
		keywords.Add ("go to the near star", () => GoToNearestStar());

		//---

		keywords.Add ("hal take me to the closest star", () => GoToNearestStar());
		keywords.Add ("hal take me to the nearest star", () => GoToNearestStar());
		keywords.Add ("hal take me to a near star", () => GoToNearestStar());

		keywords.Add ("hal move to closest star", () => GoToNearestStar());
		keywords.Add ("hal move to nearest star", () => GoToNearestStar());
		keywords.Add ("hal move to near star", () => GoToNearestStar());

		keywords.Add ("hal go to closest star", () => GoToNearestStar());
		keywords.Add ("hal go to nearest star", () => GoToNearestStar());
		keywords.Add ("hal go to near star", () => GoToNearestStar());

		keywords.Add ("hal go to the closest star", () => GoToNearestStar());
		keywords.Add ("hal go to the nearest star", () => GoToNearestStar());
		keywords.Add ("hal go to the near star", () => GoToNearestStar());
	}

	void GoHomeSpeechInputs(){
		
		keywords.Add ("go home", () => GoHome());
		keywords.Add ("go hone", () => GoHome());
		keywords.Add ("go phone", () => GoHome());
		keywords.Add ("go moan", () => GoHome());
		keywords.Add ("go sown", () => GoHome());
		keywords.Add ("go foam", () => GoHome());

		keywords.Add ("hal go home", () => GoHome());
		keywords.Add ("hal take me home", () => GoHome());
		keywords.Add ("hal go phone", () => GoHome());
		keywords.Add ("hal go moan", () => GoHome());
		keywords.Add ("hal go sown", () => GoHome());
		keywords.Add ("hal go foam", () => GoHome());

	}

	void TestRawOutput(string text, ConfidenceLevel confidence){
		print(text);
	}

	void GoToRandomStar(){
		print ("GO TO RANDOM STAR");
		if (goToRandomStar != null)
			goToRandomStar ();
	}

	void GoToNearestPlanet(){
		print (speechInput);
	}

	void GoToNearestStar(){
		print ("GO TO NEAREST STAR");
		if (goToNearestStar != null)
			goToNearestStar ();
	}

	void GoHome(){
		print ("GO HOME");
		if (goHome != null)
			goHome ();
	}
		
}
