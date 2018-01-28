using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	private LevelManagerController levelManager;
	public int coinValue;

	void Start(){
		levelManager = FindObjectOfType<LevelManagerController>();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			levelManager.AddCoin(coinValue);
			Destroy(gameObject);
		}
	}

}
