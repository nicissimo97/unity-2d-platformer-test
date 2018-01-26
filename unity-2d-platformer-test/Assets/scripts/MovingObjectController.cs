using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectController : MonoBehaviour {

	public GameObject objToMove;
	public Transform startPoint;
	public Transform endPoint;
	public float speed;
	private Vector3 currentTarget;

	void Start () {
		currentTarget = endPoint.position;
	}

	void Update () {
		objToMove.transform.position = Vector3.MoveTowards (objToMove.transform.position, currentTarget, speed * Time.deltaTime);
		if (objToMove.transform.position == endPoint.position) {
			currentTarget = startPoint.position;
		}
		if (objToMove.transform.position == startPoint.position) {
			currentTarget = endPoint.position;
		}

	}
}
