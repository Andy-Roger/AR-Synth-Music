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

		if (btnPress == true) {
			foreach (GameObject effectDial in GameObject.FindGameObjectsWithTag("echoDial"))
			{
				effectDial.transform.Rotate (Vector3.forward * 80 * Time.deltaTime, Space.Self); 
				effect.delay = effectDial.transform.rotation.eulerAngles.z * 20;
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