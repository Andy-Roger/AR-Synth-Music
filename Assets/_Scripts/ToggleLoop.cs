using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ToggleLoop : MonoBehaviour, IVirtualButtonEventHandler {

	AudioEchoFilter delay;
	GameObject cam;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		cam = GameObject.Find ("ARCamera");
		delay = cam.GetComponent<AudioEchoFilter> ();
		delay.decayRatio = 1;

		if (delay.decayRatio <= 0.7f) {
			delay.decayRatio = 1;
			foreach(GameObject loopText in GameObject.FindGameObjectsWithTag("soundText3")){
				loopText.GetComponent<TextMesh>().text = "LOOPER:    ON";
			}
		}else{
			delay.decayRatio = .5f;
			foreach(GameObject loopText in GameObject.FindGameObjectsWithTag("soundText3")){
				loopText.GetComponent<TextMesh>().text = "LOOPER:    OFF";
			}
		}
	}

	void Update () {
		
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		if (delay.decayRatio <= 0.7f) {
			delay.decayRatio = 1;
			foreach(GameObject loopText in GameObject.FindGameObjectsWithTag("soundText3")){
				loopText.GetComponent<TextMesh>().text = "LOOPER:    ON";
				}
		}else{
			delay.decayRatio = .5f;
			foreach(GameObject loopText in GameObject.FindGameObjectsWithTag("soundText3")){
				loopText.GetComponent<TextMesh>().text = "LOOPER:    OFF";
			}
		}
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
	}
}