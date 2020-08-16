using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlatMovement player;

	public GameObject deathParticles;
	public GameObject respawnParticles;

	public float respawnDelay;

	void Start () {

		player = FindObjectOfType<PlatMovement> ();

	}

	public void RespawnPlayer() {

		StartCoroutine ("RespawnPlayerCo");

	}

	public IEnumerator RespawnPlayerCo() {

		Instantiate (deathParticles, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		Debug.Log ("Jogador renascido");
		yield return new WaitForSeconds (respawnDelay);
		player.GetComponent<Rigidbody2D> ().gravityScale = 5;
		player.transform.position = currentCheckpoint.transform.position;
		player.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		Instantiate (respawnParticles, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

	}

}
