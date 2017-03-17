using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ToggleLoop : MonoBehaviour, IVirtualButtonEventHandler {

	AudioEchoFilter delay;
	GameObject cam;
	private bool looperIsOn;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		cam = GameObject.Find ("ARCamera");
		delay = cam.GetComponent<AudioEchoFilter> ();
		delay.decayRatio = .5f;
		looperIsOn = false;

		//set ui
		GameObject.FindGameObjectWithTag("soundText3").GetComponent<TextMesh>().text = "LOOPER:    OFF";
	}

	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		looperIsOn = !looperIsOn;

		if (looperIsOn) {
			delay.decayRatio = 1;
			//set ui
			GameObject.FindGameObjectWithTag("soundText3").GetComponent<TextMesh>().text = "LOOPER:    ON";
		}else{
			delay.decayRatio = .5f;
			//set ui
			GameObject.FindGameObjectWithTag("soundText3").GetComponent<TextMesh>().text = "LOOPER:    OFF";
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
	}
}