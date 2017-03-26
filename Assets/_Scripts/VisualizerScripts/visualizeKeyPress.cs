using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeKeyPress : MonoBehaviour {

	float i;
	Vector3[] axies = new Vector3[3];
	int index;

	void Start () {
		axies [0] = Vector3.up;
		axies [1] = Vector3.forward;
		axies [2] = Vector3.down;
	}
	
	void Update () {
		// loops through keys and checks whether any were pressed
		// if pressed then initiate attack trigger - or whatever
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			if ( key.GetComponent<BasicButtonBehavior>().buttonIsPressed ) {
				StartCoroutine(doVisuals ());
				index = Random.Range (0, axies.Length);
			}
		}
		changeSpheresDirection ();
	}

	IEnumerator doVisuals(){
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			if (cube != null) {
				cube.GetComponent<Animator> ().SetTrigger ("AttackTrigger");
				yield return new WaitForSeconds (0.0001f);
			}
		}
	}

	void changeSpheresDirection(){
		if (GameObject.FindGameObjectWithTag ("sphereHolder") != null) {
			foreach (GameObject points in GameObject.FindGameObjectsWithTag ("sphereVisualObjs")) {
				points.transform.RotateAround (points.transform.parent.position, axies[index], 100 * Time.deltaTime);
			}
		}
	}
}
