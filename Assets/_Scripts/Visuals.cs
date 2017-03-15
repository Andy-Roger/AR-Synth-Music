using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visuals : MonoBehaviour {

	void Start () {
		foreach (GameObject rot in GameObject.FindGameObjectsWithTag("rotate")) {
			rot.transform.rotation = new Quaternion(Random.Range(-180,180), Random.Range(-180,180), Random.Range(-180,180),1);
		}
	}
	void Update () {
		beat ();
	}

	void beat(){
		if (Input.GetKeyUp (KeyCode.A)) {
			foreach (GameObject visuals in GameObject.FindGameObjectsWithTag("visuals1")) {
				visuals.GetComponent<Animator> ().SetTrigger ("beat");
			}
		};
	}
}
