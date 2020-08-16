using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComidaControle : MonoBehaviour {

	// Atenção! Esse código é ridículo. Por favor não olhe...

	public Sprite ZBurger1;
	public Sprite ZBurger2;
	public Sprite ZBurger3;
	public Sprite Djonais1;
	public Sprite Djonais2;
	public Sprite Djonais3;
	public Sprite Djindim1;
	public Sprite Djindim2;
	public Sprite Djindim3;
	public Sprite None;
	public SpriteRenderer sr;

    public static Sprite Comida;
    public static int quantoComido;

    void Start () {

		sr = GetComponent<SpriteRenderer> ();

		ChangeComida ();

	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			quantoComido += 1;
			ChangeComida ();

		}

	}

	public void ChangeComida () {

		if (quantoComido == 0) {

			if (Comida == ZBurger1) { sr.sprite = ZBurger1; }
			if (Comida == Djonais1) { sr.sprite = Djonais1; }
			if (Comida == Djindim1) { sr.sprite = Djindim1; }

		}

		if (quantoComido == 1) {

			if (Comida == ZBurger1) { sr.sprite = ZBurger2; }
			if (Comida == Djonais1) { sr.sprite = Djonais2; }
			if (Comida == Djindim1) { sr.sprite = Djindim2; }

		}

		if (quantoComido == 2) {

			if (Comida == ZBurger1) { sr.sprite = ZBurger3; }
			if (Comida == Djonais1) { sr.sprite = Djonais3; }
			if (Comida == Djindim1) { sr.sprite = Djindim3; }

		}

		if (quantoComido >= 3) {

			sr.sprite = None;

		}

	}

	// AAAAAH eu avisei!! >:(

}
