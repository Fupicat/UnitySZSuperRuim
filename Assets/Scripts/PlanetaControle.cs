using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameJolt.API;

public class PlanetaControle : MonoBehaviour {

	public static Vector3 PlanetDirection;                  //Direction of the current planet
	public static string CurrentPlanet;                     //Current/last planet

    private static bool lastFlat;                           //Is the last planet flat?
    private static Vector3 prevDirection;                   //The direction of the previous planet

	public bool Flat;                                       //Planeta é plano?
    public bool flatChild;                                  //Parte de planeta plano?
    public GameObject flatFather;                           //Pai das partes do planeta plano?

	public float PlanetVel;                                 //Velocidade

	public bool canMove = true;                             //Jogador pode se mover?

    public GJSave Save;

    void Start () {

        if (SceneManager.GetActiveScene().name == "ClobePengoen")
            GameJoltManager.UnlockTrophy(94799);

        if (SceneManager.GetActiveScene().name == "PlanetaCentral")
            GameJoltManager.UnlockTrophy(94786);

		if (Flat) {

			//if (PlanetDirection == Vector3.zero || !lastFlat) {

				PlanetDirection = transform.position; //Se o último planeta não for plano, mude o PlanetDirection para a posição atual.

			//}

			transform.position = PlanetDirection;
            lastFlat = true;

		} else {

            if (!flatChild) {

                if (lastFlat)
                    PlanetDirection = prevDirection;

                transform.rotation = Quaternion.Euler(PlanetDirection);
                lastFlat = false;
            }

        }

		CurrentPlanet = SceneManager.GetActiveScene ().name;
		canMove = true;

	}

	void Update () {

		if (!canMove) {
            if (flatChild)
                canMove = flatFather.GetComponent<PlanetaControle>().canMove;
            return;
		}

        if (flatChild)
        {
            transform.position = new Vector3(flatFather.transform.position.x, flatFather.transform.position.y, transform.position.z);
            canMove = flatFather.GetComponent<PlanetaControle>().canMove;
            return;
        }

        if (Input.GetKey (KeyCode.A))
        	RotateLeft ();

        if (Input.GetKey (KeyCode.D))
        	RotateRight ();

        if (Flat) {
			PlanetDirection = transform.position;
		} else {
			PlanetDirection = transform.eulerAngles;
            prevDirection = PlanetDirection;
		}
	}

	void RotateRight () {
		if (Flat) {
			transform.position -= Vector3.right * PlanetVel * Time.deltaTime;
		} else {
			transform.Rotate (Vector3.forward * PlanetVel * Time.deltaTime);
		}
	}

	void RotateLeft () {
		if (Flat) {
			transform.position -= Vector3.left * PlanetVel * Time.deltaTime;
		} else {
			transform.Rotate (Vector3.back * PlanetVel * Time.deltaTime);
		}
	}
}
