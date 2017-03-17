using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeSound : MonoBehaviour, IVirtualButtonEventHandler {

	AudioSource[] sources;
	GameObject sounds;
	AudioClip soundName;
	int iterator;
	AudioClip[] clips = new AudioClip[12];

	void Start () {
		sounds = GameObject.Find ("Sounds");
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		sources = sounds.GetComponentsInChildren<AudioSource> ();
		iterator = 0;
		clips[0] = Resources.Load ("Demung") as AudioClip;
		clips[1] = Resources.Load ("arpeggio") as AudioClip;
		clips[2] = Resources.Load ("chordsy") as AudioClip;
		clips[3] = Resources.Load ("sawtooth") as AudioClip;
		clips[4] = Resources.Load ("triangle") as AudioClip;
		clips[5] = Resources.Load ("square") as AudioClip;
		clips[6] = Resources.Load ("sine") as AudioClip;
		clips[7] = Resources.Load ("toy piano") as AudioClip;
		clips[8] = Resources.Load ("viola") as AudioClip;
		clips[9] = Resources.Load ("steel drum") as AudioClip;
		clips[10] = Resources.Load ("glass pad") as AudioClip;
		clips[11] = Resources.Load ("Rhodes") as AudioClip;
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		
		iterator++;
		if (iterator == clips.Length){ iterator = 0; }

		foreach (AudioSource source in sources) {
			source.clip = clips[iterator];
		}

		GameObject.FindGameObjectWithTag("soundText").GetComponent<TextMesh>().text = "SAMPLE:    " + clips[iterator].name.ToUpper();
	}
		
	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}

	void Update () {}
}
