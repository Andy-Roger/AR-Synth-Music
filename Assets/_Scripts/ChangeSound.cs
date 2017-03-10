using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ChangeSound : MonoBehaviour, IVirtualButtonEventHandler {

	AudioSource[] sources;
	GameObject sounds;
	AudioClip soundName;
	int iterator;
	AudioClip[] clips = new AudioClip[14];

	void Start () {
		sounds = GameObject.Find ("Sounds");
		gameObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);
		sources = sounds.GetComponentsInChildren<AudioSource> ();
		iterator = 0;
		clips[0] = Resources.Load ("retrobah") as AudioClip;
		clips[1] = Resources.Load ("pan") as AudioClip;
		clips[2] = Resources.Load ("boop") as AudioClip;
		clips[3] = Resources.Load ("square") as AudioClip;
		clips[4] = Resources.Load ("triangle") as AudioClip;
		clips[5] = Resources.Load ("sawtooth") as AudioClip;
		clips[6] = Resources.Load ("Demung") as AudioClip;
		clips[7] = Resources.Load ("arpy") as AudioClip;
		clips[8] = Resources.Load ("blaster") as AudioClip;
		clips[9] = Resources.Load ("toy piano") as AudioClip;
		clips[10] = Resources.Load ("fly chords") as AudioClip;
		clips[11] = Resources.Load ("zapper") as AudioClip;
		clips[12] = Resources.Load ("viola") as AudioClip;
		clips[13] = Resources.Load ("robo strings") as AudioClip;
	}

	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb){
		
		iterator++;
		if (iterator == clips.Length){ iterator = 0; }
		foreach (AudioSource source in sources) {
			source.clip = clips[iterator];

			foreach(GameObject soundName in GameObject.FindGameObjectsWithTag("soundText"))
			{
				soundName.GetComponent<TextMesh>().text = "SAMPLE:    " + clips[iterator].name.ToUpper();
			}
		}
	}
		
	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb){}

	void Update () {}
}
