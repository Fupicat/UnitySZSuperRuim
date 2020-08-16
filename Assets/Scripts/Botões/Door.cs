using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour {

	public string Lugar;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public static bool podePegar = true;

	public Image black;
	public Animator anim;

	void OnMouseEnter() {
		
			Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);

	}

	void OnMouseExit() {
		
		Cursor.SetCursor(null, Vector2.zero, cursorMode);

	}

	void OnMouseDown () {
		
		if (Lugar == "SegredoDjangia") {
			
			if (podePegar == true) {
				
				StartCoroutine (Fading ());

			}

		} else {
			
			StartCoroutine (Fading ());

		}

	}

	IEnumerator Fading() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
		SceneManager.LoadScene (Lugar);

	}

}
