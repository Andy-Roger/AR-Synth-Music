using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeSounds : MonoBehaviour {

	GameObject cam;
	AudioSource sound;
	GameObject changeSoundBtn;
	string soundName;
	string privateName;
	public Mesh mesh1;
	public Mesh mesh2;
	public Mesh mesh3;
	float xPos;
	float zPos;

	void Start () {
		xPos = -5f;
		zPos = -.5f;
		cam 	= GameObject.Find ("Sound1");
		sound 	= cam.GetComponent<AudioSource> ();
		changeSoundBtn = GameObject.FindGameObjectWithTag ("changeSound");
		soundName = changeSoundBtn.GetComponent<ChangeSound> ().soundString;
	}

	void Update () {
		//check which sound is currently playing
		// and do something for each sound - like change the mesh

		soundName = changeSoundBtn.GetComponent<ChangeSound> ().soundString;

		if (privateName != soundName) {
			//change watcher
			privateName = soundName;
			changeMesh(nameOfSound: soundName);
		}
	}

	// Depending on what sound is playing, change the mesh

	public void changeMesh(string nameOfSound){
		switch (nameOfSound) {

		case "arpeggio":
			foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
				visualObjs.GetComponent<MeshFilter> ().mesh = mesh1;
			}
			break;

		case "chordsy":
			foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
				visualObjs.GetComponent<MeshFilter> ().mesh = mesh2;
			}
			break;

		case "sawtooth":
			xPos = -.6f;
			zPos = -.5f;
			foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
				xPos += .1f;
				visualObjs.GetComponent<MeshFilter> ().mesh = mesh3;
				if (xPos >= .5f) {
					xPos = -.5f;
					zPos += .1f;
				}

				visualObjs.GetComponent<MeshFilter> ().mesh = mesh3;
				visualObjs.transform.localPosition = new Vector3 (xPos, -1f, zPos);
				visualObjs.transform.localRotation = new Quaternion (0, 0, 0, 1);
				visualObjs.transform.localScale = new Vector3 (1,.5f,1);

			}
			break;

		default:
			Debug.Log ("do nothing");
			break;
		}
	}
}
