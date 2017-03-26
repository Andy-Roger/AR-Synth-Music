using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visualizeSounds : MonoBehaviour {

	GameObject cam;
	AudioSource sound;
	GameObject changeSoundBtn;
	string soundName;
	string privateName;
	public Mesh mesh;
	public GameObject prefab;
	public Transform visContainer;
	public int numberOfPoints = 40;

	void Start () {
		cam 	= GameObject.Find ("Sound1");
		sound 	= cam.GetComponent<AudioSource> ();
		changeSoundBtn = GameObject.FindGameObjectWithTag ("changeSound");
		soundName = changeSoundBtn.GetComponent<ChangeSound> ().soundString;
		makeVisObjs (numOfObjs: 60);
		rotatingBarsVisual ();
	}

	void makeVisObjs(float numOfObjs){
		for (float i = 0; i < numOfObjs; i++) {
			Object.Instantiate (prefab, visContainer);
		}
	}

	void rotatingBarsVisual(){
		foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
			visualObjs.GetComponent<MeshFilter> ().mesh = mesh;
			visualObjs.transform.localPosition = new Vector3 (0, 0, 0);
			visualObjs.transform.localRotation = new Quaternion (Random.Range(1,360),Random.Range(1,360),Random.Range(1,360),1);
		}
	}

	// called inside of makeVisObjs

//	void destroyVisObjs(){
//		foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
//			Destroy (visualObjs);
//		}
//		foreach (GameObject sphereVisualObjs in GameObject.FindGameObjectsWithTag("sphereVisualObjs")) {
//			Destroy (sphereVisualObjs);
//		}
//		Destroy(GameObject.FindGameObjectWithTag("sphereHolder"));
//	}
//
//	// visual #1
//
//	void gridVisual(){
//		xPos = -.6f;
//		zPos = -.5f;
//		foreach (GameObject visualObjs in GameObject.FindGameObjectsWithTag("visualizerCubes")) {
//			xPos += .1f;
//
//			if (xPos >= .5f) {
//				xPos = -.5f;
//				zPos += .1f;
//			}
//
//			visualObjs.GetComponent<MeshFilter> ().mesh = mesh3;
//			visualObjs.transform.localPosition = new Vector3 (xPos, 0f, zPos);
//			visualObjs.transform.localRotation = new Quaternion (0, 0, 0, 1);
//			visualObjs.transform.localScale = new Vector3 (1, .1f, 1);
//			visualObjs.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 0.1f);
//		}
//	}
//
//	// visual #2
//
//
//	// visual #3
//
//	void sphereVisual(){
//
//		GameObject sphereHolder = GameObject.FindGameObjectWithTag ("Visualizer");
//		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//		sphere.tag = "sphereHolder";
//		sphere.transform.parent = sphereHolder.transform;
//		GameObject pointsHolder = GameObject.FindGameObjectWithTag ("sphereHolder");
//		pointsHolder.transform.localPosition = new Vector3(0,0,0);
//		pointsHolder.transform.localScale = new Vector3 (.7f,.7f,.7f);
//
//		Vector3[] myPoints = GetPointsOnSphere(numberOfPoints);
//
//		foreach (Vector3 point in myPoints)
//		{
//			GameObject outerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			outerSphere.transform.parent = pointsHolder.transform;
//			outerSphere.transform.localPosition = point * 1f;
//			outerSphere.transform.localScale = new Vector3(.3f,.3f,.3f);
//			outerSphere.tag = "sphereVisualObjs";
//		}
//	}
//	Vector3[] GetPointsOnSphere(int nPoints)
//	{
//		float fPoints = (float)nPoints;
//
//		Vector3[] points = new Vector3[nPoints];
//
//		float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
//		float off = 2 / fPoints;
//
//		for (int k = 0; k < nPoints; k++)
//		{
//			float y = k * off - 1 + (off / 2);
//			float r = Mathf.Sqrt(1 - y * y);
//			float phi = k * inc;
//
//			points[k] = new Vector3(Mathf.Cos(phi) * r, y, Mathf.Sin(phi) * r);
//		}
//
//		return points;
//	}
}
