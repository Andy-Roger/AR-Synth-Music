using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeKeyPress : MonoBehaviour {

	public GameObject prefab;
	public Transform visContainer;
	float i;

	void Start () {
		makeVis1 ();
	}
	
	void Update () {
		// loops through keys and checks whether any were pressed
		// if pressed then initiate attack trigger - or whatever
		foreach (GameObject key in GameObject.FindGameObjectsWithTag("key")) {
			if ( key.GetComponent<BasicButtonBehavior>().buttonIsPressed ) {
				StartCoroutine(doVisuals ());
			}
		}
	}

	IEnumerator doVisuals(){
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			cube.GetComponent<Animator> ().SetTrigger ("AttackTrigger");
			yield return new WaitForSeconds (0.0001f);
		}
	}

	void makeVis1(){
		for (i = 0; i < 121; i++) {
			Object.Instantiate (prefab,visContainer);
		}

		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			cube.transform.localPosition = new Vector3 (0,0,0);
			cube.transform.rotation = new Quaternion (Random.Range (180,-180), Random.Range (180,-180), Random.Range (180,-180), 1);
			cube.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 0.1f);
		}
	}
}
