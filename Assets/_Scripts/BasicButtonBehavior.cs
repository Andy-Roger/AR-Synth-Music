using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;

public class BasicButtonBehavior : MonoBehaviour, IVirtualButtonEventHandler {
	
	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
	}

	void Update () {
		
	}
}
