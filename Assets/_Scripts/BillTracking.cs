using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BillTracking : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	public GameObject littleBuddy;


	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
			
	}

	// tracks if a bill is detected. All stuff that happens on detection or lost goes here

	public void OnTrackableStateChanged( TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			littleBuddy.GetComponent<Animator>().SetBool("tracked", true);

			Renderer[] rendererComponents = littleBuddy.GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = littleBuddy.GetComponentsInChildren<Collider>(true);

			// Enable Renderers
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			StartCoroutine(doButtonJump ());

			Invoke ("fadeInVisualizer", 1);

		}
		else
		{
			littleBuddy.GetComponent<Animator>().SetBool("tracked", false);

			Renderer[] rendererComponents = littleBuddy.GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = littleBuddy.GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
		}
	}


	// activates the buttons animator to jump in sequence
	IEnumerator doButtonJump(){
		foreach (GameObject notebtn in GameObject.FindGameObjectsWithTag("notebtn")) {
			if (notebtn != null) {
				notebtn.GetComponent<Animator> ().SetTrigger ("buttonJump");
				yield return new WaitForSeconds (0.01f);
			}
		}
	}

	void fadeInVisualizer(){
		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			if (cube != null) {
				cube.GetComponent<Renderer> ().material.color = new Color(.1f,.1f,.1f,.1f);
			}
		}
	}
}