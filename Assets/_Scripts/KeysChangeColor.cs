using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class KeysChangeColor : MonoBehaviour, IVirtualButtonEventHandler {

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		Invoke ("randomizeKeyColor", .1f);
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			key.GetComponentInChildren<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1.0f);
		}
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
	}

	void randomizeKeyColor(){
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			key.GetComponentInChildren<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1.0f);
		}
	}
}
