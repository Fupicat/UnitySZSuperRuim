using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.UI;
using UnityEngine.SceneManagement;

public class ScratControle : MonoBehaviour {

	public bool Andando;                                    //O jogador está andando?

	private Animator anim;
    private Animator animPlaneta;

	public bool canMove = true;                             //O jogador pode mover?

    public bool planetHasWater;                             //Planeta tem água?
    public bool water;                                      //Jogador na água?

    void Start () {
		anim = GetComponent<Animator> ();

        if (GameObject.FindGameObjectWithTag("Planeta").GetComponent<Animator>() != null)
            animPlaneta = GameObject.FindGameObjectWithTag("Planeta").GetComponent<Animator>();

        water = false;
		Andando = false;
		canMove = true;
	}

	void Update () {

		if (!canMove) {
			Andando = false;
            anim.SetBool("IsWalking", false);
            return;
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			Andando = true;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			Andando = true;
		}

		if (Input.GetKeyUp (KeyCode.A))
			Andando = false;

		if (Input.GetKeyUp (KeyCode.D))
			Andando = false;

        if (Input.GetKey(KeyCode.S))
            if (planetHasWater)
                water = true;

        if (Input.GetKey(KeyCode.W))
            if (planetHasWater)
                water = false;

        if (Input.GetKey (KeyCode.C))
			CredsSystem.credsTotal += 10;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GJSave.Save();
            SceneManager.LoadScene("MainMenu");
        }	

        if (Input.GetKeyDown(KeyCode.P))
            GJSave.Save();

        if (Input.GetKeyDown(KeyCode.O))
        {
            GJSave.GJLoad();
        }

		anim.SetBool ("IsWalking", Andando);
        anim.SetBool("Swimming?", water);

        if (animPlaneta != null)
            animPlaneta.SetBool("Water?", water);

    }
}