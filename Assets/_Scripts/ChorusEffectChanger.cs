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

		if (btnPress == true) {
			
			foreach (GameObject effectDial in GameObject.FindGameObjectsWithTag("chorusDial"))
			{
				effectDial.transform.Rotate (Vector3.forward * 80 * Time.deltaTime); 
				effect.rate = effectDial.transform.rotation.eulerAngles.z / 17;
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