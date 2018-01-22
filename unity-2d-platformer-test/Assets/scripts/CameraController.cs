﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float followAhead;
	private Vector3 targetPosition;
	public float smoothing;

	void Update () {
		targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

		if (target.transform.localScale.x > 0f) {
			targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
		} else {
			targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
		}
			
		transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
	}
}