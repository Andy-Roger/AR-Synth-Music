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
	GameObject particleObj;
	ParticleSystem ps;

	public float hSliderValueR = 0.0F;
	public float hSliderValueG = 0.0F;
	public float hSliderValueB = 0.0F;
	public float hSliderValueA = 1.0F;

	void Start () {
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		source = soundSource.GetComponent<AudioSource> ();
		source.clip = Resources.Load ("Demung") as AudioClip;
		source.volume = .4f;
		particleObj = GameObject.FindGameObjectWithTag ("particles");
		ps = particleObj.GetComponent<ParticleSystem> ();
		ps.enableEmission = false;
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		source.Play ();
		source.loop = true;
		ps.enableEmission = true;
		var main = ps.main;
		main.startColor = new Color(Random.value,Random.value,Random.value,hSliderValueA);
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){
		source.loop = false;
		ps.enableEmission = false;
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
