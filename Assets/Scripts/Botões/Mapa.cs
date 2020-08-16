using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mapa : MonoBehaviour {

	public string Lugar;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public Image black;
	public Animator anim;

	void OnMouseEnter() {

		Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);

	}

	void OnMouseExit() {

		Cursor.SetCursor(null, Vector2.zero, cursorMode);

	}

	void OnMouseDown () {

		StartCoroutine (Fading ());

	}

	IEnumerator Fading() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
		PlanetaControle.CurrentPlanet = Lugar;
		PlanetaControle.PlanetDirection = Vector3.zero;
		SceneManager.LoadScene (Lugar);

	}

}
