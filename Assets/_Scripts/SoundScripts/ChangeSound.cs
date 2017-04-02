using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeSound : MonoBehaviour, IVirtualButtonEventHandler {

	AudioSource[] sources;
	GameObject sounds;
	AudioClip soundName;
	int iterator;
	AudioClip[] clips = new AudioClip[6];
	GameObject visSphere;
	public string soundString;

	void Start () {
		visSphere = GameObject.FindGameObjectWithTag ("Visualizer");
		sounds = GameObject.Find ("Sounds");
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		sources = sounds.GetComponentsInChildren<AudioSource> ();
		iterator = 0;

		//TODO take out demung, toy piano, rhodes, organ, 

		clips[0] = Resources.Load ("fuzz") as AudioClip;
		clips[1] = Resources.Load ("glass pad") as AudioClip;
		clips[2] = Resources.Load ("arpeggio") as AudioClip;
		clips[3] = Resources.Load ("derp") as AudioClip;
		clips[4] = Resources.Load ("viola") as AudioClip;
		clips[5] = Resources.Load ("derp") as AudioClip;
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		
		iterator++;
		if (iterator == clips.Length){ iterator = 0; }

		foreach (AudioSource source in sources) {
			source.clip = clips[iterator];
		}

		soundString = clips [iterator].name;
	}
		
	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}

	void Update () {}
}
