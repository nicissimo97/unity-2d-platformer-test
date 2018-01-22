using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	public Sprite checkpointGreen;
	public Sprite checkpointRed;
	public SpriteRenderer spriteRenderer;
	public bool checkpointActive;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			spriteRenderer.sprite = checkpointGreen;
			checkpointActive = true;
		}
	}
}
