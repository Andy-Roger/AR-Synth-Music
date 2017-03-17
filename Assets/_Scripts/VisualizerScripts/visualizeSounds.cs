using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeSounds : MonoBehaviour {

	GameObject cam;
	AudioSource sound;

	void Start () {
		cam 	= GameObject.Find ("ARCamera");
		sound 	= cam.GetComponent<AudioSource> ();
	}
	
	void Update () {
		//check which sound is currently playing
		// and do something for each sound - like change the mesh
	}
}
