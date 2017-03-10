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

		if (btnPress == true) {
			foreach (GameObject effectDial in GameObject.FindGameObjectsWithTag("reverbDial"))
			{
				effectDial.transform.Rotate (Vector3.forward * 80 * Time.deltaTime); 
				effect.decayTime = effectDial.transform.rotation.eulerAngles.z / 17;
			}
		} 
	}

	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {
		btnPress = true;
	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb) {
		btnPress = false;
	}
}