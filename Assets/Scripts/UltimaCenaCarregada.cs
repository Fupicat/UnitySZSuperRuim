using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UltimaCenaCarregada : MonoBehaviour {

	public Image black;
	public Animator anim;

	public void ToLastScene() {

        if (black == null)
        {
            black = GameObject.FindWithTag("Fade").GetComponent<Image>();
            anim = GameObject.FindWithTag("Fade").GetComponent<Animator>();
        }

        StartCoroutine (CoLastScene ());

	}

	IEnumerator CoLastScene() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene (PlanetaControle.CurrentPlanet);

	}

}
