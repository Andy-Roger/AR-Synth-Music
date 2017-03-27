using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChorusEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	AudioChorusFilter effect;
	public bool btnPress;
	GameObject cam;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		cam = GameObject.Find ("ARCamera");
		effect = cam.GetComponent<AudioChorusFilter> ();
		btnPress = false;
	}

	void Update () {
		
		if (effect.rate >= 20) {
			effect.rate = 0;
		};
		if (effect.rate < 2) {
			effect.enabled = false;
		} else {
			effect.enabled = true;
		}

		if (btnPress == true) {
			effect.rate += .05f;

		}

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}