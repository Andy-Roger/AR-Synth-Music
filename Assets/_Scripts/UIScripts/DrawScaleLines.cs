﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScaleLines : MonoBehaviour {

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	int lengthOfLineRenderer = 20;
	public float size = 0.5f;

	void Start() {

		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material (Shader.Find("Particles/Additive"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.numPositions = lengthOfLineRenderer;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineRenderer.colorGradient = gradient;
	}

	void Update() {

		LineRenderer lineRenderer = GetComponent<LineRenderer> ();
		var t = Time.time;
		for (int i = 0; i < lengthOfLineRenderer; i++) {
			lineRenderer.SetPosition (i, new Vector3 (i * size, Mathf.Sin (i * t), 0.0f));
		}
	}
}
