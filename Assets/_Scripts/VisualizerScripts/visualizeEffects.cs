using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeEffects : MonoBehaviour {

	GameObject cam;
	AudioReverbFilter reverb;
	AudioEchoFilter echo;
	AudioChorusFilter chorus;

	void Start () {
		cam 	= GameObject.Find ("ARCamera");
		reverb 	= cam.GetComponent<AudioReverbFilter> ();
		echo 	= cam.GetComponent<AudioEchoFilter> ();
		chorus 	= cam.GetComponent<AudioChorusFilter> ();
	}


	void Update () {

		// add reverb effect to visualizer
		float decay = reverb.decayTime;
		float delay = echo.delay;
		float rate = chorus.rate;

//		gameObject.transform.localPosition = new Vector3(delay, decay, rate);
	}
}
