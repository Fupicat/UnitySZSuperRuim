using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour {

    public static int gameID;
    public static int credsGanhos;

    public Text msgFim;

    public string[] ondeIr = { "WalkRestaurante", "level1", "level2" };

	void Start () {

        msgFim.text = ("Você ganhou " + credsGanhos + " creds!");

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(ondeIr[gameID]);
        }
    }
}
