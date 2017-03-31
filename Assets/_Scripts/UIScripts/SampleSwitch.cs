using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleSwitch : MonoBehaviour {

	GameObject soundObj;
	GameObject sample1;
	GameObject sample2;
	GameObject sample3;
	GameObject sample4;
	GameObject sample5;
	GameObject sample6;

	AudioSource source;

	void Start () {
		soundObj = GameObject.FindGameObjectWithTag ("clip");
		source = soundObj.GetComponent<AudioSource> ();

		sample1 = GameObject.FindGameObjectWithTag ("sample1");
		sample2 = GameObject.FindGameObjectWithTag ("sample2");
		sample3 = GameObject.FindGameObjectWithTag ("sample3");
		sample4 = GameObject.FindGameObjectWithTag ("sample4");
		sample5 = GameObject.FindGameObjectWithTag ("sample5");
		sample6 = GameObject.FindGameObjectWithTag ("sample6");

	}
	
	// Update is called once per frame
	void Update () {
		dotPlacement ();
	}

	void dotPlacement(){
		switch(source.clip.name){
		case "fuzz":
			transform.position = new Vector3 (sample1.transform.position.x, sample1.transform.position.y, sample1.transform.position.z);
			break;
		case "glass pad":
			transform.position = new Vector3 (sample2.transform.position.x, sample2.transform.position.y, sample2.transform.position.z);
			break;
		case "arpeggio":
			transform.position = new Vector3 (sample3.transform.position.x, sample3.transform.position.y, sample3.transform.position.z);
			break;
		case "triangle":
			transform.position = new Vector3 (sample4.transform.position.x, sample4.transform.position.y, sample4.transform.position.z);
			break;
		case "viola":
			transform.position = new Vector3 (sample5.transform.position.x, sample5.transform.position.y, sample5.transform.position.z);
			break;
		case "derp":
			transform.position = new Vector3 (sample6.transform.position.x, sample6.transform.position.y, sample6.transform.position.z);
			break;
		default: 
			return;
			break;
		}
	}
}
