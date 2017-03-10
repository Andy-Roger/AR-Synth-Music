using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerLook : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () { 
		camFollow ();
	}
	void camFollow(){
		gameObject.transform.LookAt (target);
	}
}
