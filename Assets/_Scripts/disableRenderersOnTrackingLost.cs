using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class disableRenderersOnTrackingLost : MonoBehaviour {
	bool found;

	void Update(){
		checkStatus ();
		if (found) {
			OnTrackingFound ();
		} else {
			OnTrackingLost ();
		}
	}

	void checkStatus(){
		foreach (GameObject bill in GameObject.FindGameObjectsWithTag("bill")) {
			found = bill.GetComponent<DefaultTrackableEventHandler> ().billTracked;
		}
	}

	private void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		Canvas[] canvasComponents = GetComponentsInChildren<Canvas> (true);

		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;

		}

		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}

		// Enable canvas:
		foreach (Canvas component in canvasComponents)
		{
			component.enabled = true;
		}
	}


	private void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		Canvas[] canvasComponents = GetComponentsInChildren<Canvas>(true);

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

		// Disable canvas:
		foreach (Canvas component in canvasComponents)
		{
			component.enabled = false;
		}
	}
}