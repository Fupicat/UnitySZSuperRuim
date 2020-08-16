using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticles : MonoBehaviour {

	private ParticleSystem thisPS;

	void Start () {
		thisPS = GetComponent<ParticleSystem> ();
	}

	void Update () {
		if (thisPS.isPlaying)
			return;
		
		Destroy (gameObject);
	}
}
