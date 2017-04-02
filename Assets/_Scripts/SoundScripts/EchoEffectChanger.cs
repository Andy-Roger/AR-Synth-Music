using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EchoEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	AudioEchoFilter effect;
	public bool btnPress;
	GameObject cam;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		cam = GameObject.Find ("ARCamera");
		effect = cam.GetComponent<AudioEchoFilter> ();
		btnPress = false;
	}

	void Update () {
		if (effect.delay >= 5000) {
			effect.delay = 0;
		};
		if (effect.delay < 500) {
			effect.enabled = false;
		} else {
			effect.enabled = true;
		}
			
		if (btnPress == true) {
			effect.delay += 15;

		}

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}