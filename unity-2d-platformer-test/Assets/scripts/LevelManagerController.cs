using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerController : MonoBehaviour {

	public float waitToRespawn;
	public PlayerController player;
	public GameObject explosion;
	public int coinCount;
	public Text coinCountDisplay;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		coinCountDisplay.text = "Coins: " + coinCount;
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

	public void AddCoin(int coinsToAdd){
		coinCount = coinCount + coinsToAdd;
		coinCountDisplay.text = "Coins: " + coinCount;
	}
}
