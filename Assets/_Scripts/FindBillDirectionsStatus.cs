using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FindBillDirectionsStatus : MonoBehaviour {
	bool lost;

	void Update(){
		checkStatus ();
		if (lost) {
			OnTrackingLost ();
		} else {
			OnTrackingFound ();
		}
	}

	void checkStatus(){
		foreach (GameObject bill in GameObject.FindGameObjectsWithTag("bill")) {
			lost = bill.GetComponent<DefaultTrackableEventHandler> ().billTracked;
		}
	}

	private void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

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
	}


	private void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

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