using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BillTracking : MonoBehaviour, ITrackableEventHandler {

	private TrackableBehaviour mTrackableBehaviour;
	public GameObject directionsBg;
	public GameObject littleBuddy;


	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
			
	}

	public void OnTrackableStateChanged( TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) 
		{
			directionsBg.GetComponent<Animator>().SetBool("tracked", true);
			littleBuddy.GetComponent<Animator>().SetBool("tracked", true);
		}
		else
		{
			Invoke ("fadeOnBillTracked", 2);
			littleBuddy.GetComponent<Animator>().SetBool("tracked", false);
		}
	}

	void fadeOnBillTracked(){
		directionsBg.GetComponent<Animator>().SetBool("tracked", false);
	}
}