using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour {

	public AudioSource BGM;

	public void ChangeBGM(AudioClip Music) {

		BGM.Stop ();
		BGM.clip = Music;
		BGM.Play ();

	}

}
