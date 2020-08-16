using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlanetasEMenus : MonoBehaviour {

	public Image black;
	public Animator anim;

	public void Mapa() {

		StartCoroutine (CoMapa ());

	}

	public void PCentral() {

		StartCoroutine (CoPCentral ());

	}

	public void Djangia() {

		StartCoroutine (CoDjangia ());

	}

	public void Inventário() {

		StartCoroutine (CoInventário ());

	}

	IEnumerator CoMapa() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene ("Mapa");

	}

	IEnumerator CoPCentral() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		PlanetaControle.CurrentPlanet = "PlanetaCentral";
		PlanetaControle.PlanetDirection = Vector3.zero;
		SceneManager.LoadScene ("PlanetaCentral");

	}

	IEnumerator CoDjangia() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		PlanetaControle.CurrentPlanet = "Djangia";
		PlanetaControle.PlanetDirection = Vector3.zero;
		SceneManager.LoadScene ("Djangia");

	}

	IEnumerator CoInventário() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		SceneManager.LoadScene ("Inventário");

	}

}
