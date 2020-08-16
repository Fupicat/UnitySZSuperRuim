using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager levMan;

	void Start () {

		levMan = FindObjectOfType<LevelManager> ();

	}

	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.name == "Char") {

			levMan.RespawnPlayer ();

		}

	}
}
