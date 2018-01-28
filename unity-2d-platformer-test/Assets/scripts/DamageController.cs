using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

	private LevelManagerController levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManagerController> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			levelManager.Respawn();
			//Debug.Log ("OK");
		}
	}

}
