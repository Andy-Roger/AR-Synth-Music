using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour {

	private LineRenderer lr;
	private float counter = 0;
	private float dist;

	public Transform start;
	public Transform end;
    public float drawSpeed = 10;


	void Start () {
		lr = GetComponent<LineRenderer> ();
		lr.SetPosition (0, start.position);
		lr.SetWidth (.01f, .01f);

		dist = Vector3.Distance (start.position, end.position);
	}

	void Update(){
		if (counter <= dist) {
			counter += .1f / drawSpeed;

			float x = Mathf.Lerp (0, dist, counter);

			Vector3 pointA = start.position;
			Vector3 pointB = end.position;

			Vector3 pointAlongLine = x * Vector3.Normalize (pointB - pointA) + pointA;

			lr.SetPosition (1, pointAlongLine);

		}
	}

}
