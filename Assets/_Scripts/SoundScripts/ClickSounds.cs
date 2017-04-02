using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ClickSounds : MonoBehaviour, IVirtualButtonEventHandler {

	AudioSource audioS;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		audioS = GetComponent<AudioSource> ();
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		audioS.pitch = 1;
		audioS.Play();
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		audioS.pitch = .8f;
		audioS.Play();
	}
}
