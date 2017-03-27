using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ReverbEffectChanger : MonoBehaviour, IVirtualButtonEventHandler {

	AudioReverbFilter effect;
	public bool btnPress;
	GameObject cam;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		cam = GameObject.Find ("ARCamera");
		effect = cam.GetComponent<AudioReverbFilter> ();
		btnPress = false;

	}

	void Update () {

		if (effect.decayTime >= 20) {
			effect.decayTime = 0;
		};
		if (effect.decayTime < 2) {
			effect.enabled = false;
		} else {
			effect.enabled = true;
		}

		if (btnPress == true) {
			effect.decayTime += .05f;

			// updates ui
			GameObject.FindGameObjectWithTag("reverbDial").transform.Rotate (Vector3.forward * 80 * Time.deltaTime, Space.Self); 
		}

	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}