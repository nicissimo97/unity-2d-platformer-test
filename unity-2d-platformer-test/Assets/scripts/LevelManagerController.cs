﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerController : MonoBehaviour {

	public float waitToRespawn;
	public PlayerController player;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Respawn(){
		StartCoroutine ("RespawnCoroutine");
	}

	public IEnumerator RespawnCoroutine(){
		player.gameObject.SetActive (false);
		Instantiate (explosion, player.transform.position, player.transform.rotation);
		yield return new WaitForSeconds (waitToRespawn);
		player.transform.position = player.respawnPosition;
		player.gameObject.SetActive (true);
	}
}