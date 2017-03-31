using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour {

	string scale;
	string previousScale;
	public GameObject key1;

	string sample;
	string previousSample;
	public GameObject sampleBtn;

	public GameObject cam;
	AudioReverbFilter reverb;
	AudioEchoFilter echo;
	AudioChorusFilter chorus;

	float decay;
	float delay;
	float rate;

	float previousDecay;
	float previousDelay;
	float previousRate;

	void start(){
		
	}

	void Update () {
		scaleScreenMove ();
		sampleScreenMove ();
		effectScreenMove ();
	}

	// listens for scale being changed

	void scaleScreenMove(){
		scale = key1.GetComponent<PlaySound> ().activeScale;
		if (previousScale != scale) {
			previousScale = scale;

			// move screen

		}
	}

	// listens for sample being changed

	void sampleScreenMove(){
		sample = sampleBtn.GetComponent<ChangeSound> ().soundString;
		if (previousSample != sample) {
			previousSample = sample;

			// move screen

		}
	}

	// listens for effects being changed

	void effectScreenMove(){
		decay = cam.GetComponent<AudioReverbFilter> ().decayTime;
		delay = cam.GetComponent<AudioEchoFilter> ().delay;
		rate = cam.GetComponent<AudioChorusFilter> ().rate;
		if(previousDecay != decay || previousDelay != delay || previousRate != rate){
			previousDecay = decay;
			previousDelay = delay;
			previousRate = rate;
			// move screen
		}
	}
}
