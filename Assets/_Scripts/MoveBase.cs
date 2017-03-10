using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("move", .01f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void move(){
		gameObject.transform.localPosition = new Vector3 (-1f,0,0);
	}
}
