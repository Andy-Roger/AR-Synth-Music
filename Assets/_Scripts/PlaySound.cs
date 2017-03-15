using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaySound : MonoBehaviour, IVirtualButtonEventHandler {
	AudioSource source;
	public GameObject soundSource;
	public string activeScale;
	public float majorSteps;
	public float minorSteps;
	public float bluesSteps;
	public float pentatonicSteps;
	public float wholeToneSteps;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		source = soundSource.GetComponent<AudioSource> ();
		source.clip = Resources.Load ("Demung") as AudioClip;
		source.volume = .4f;
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		source.Play ();
		source.loop = true;
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		source.loop = false;
	}

	void Update(){
		
		if (activeScale == "major") {
			source.pitch = Mathf.Pow (1.059463094359f, majorSteps);
		}
		if (activeScale == "minor") {
			source.pitch = Mathf.Pow (1.059463094359f, minorSteps);
		}
		if (activeScale == "blues") {
			source.pitch = Mathf.Pow (1.059463094359f, bluesSteps);
		}
		if (activeScale == "pentatonic") {
			source.pitch = Mathf.Pow (1.059463094359f, pentatonicSteps);
		}
		if (activeScale == "whole tone") {
			source.pitch = Mathf.Pow (1.059463094359f, wholeToneSteps);
		}
	}
}
