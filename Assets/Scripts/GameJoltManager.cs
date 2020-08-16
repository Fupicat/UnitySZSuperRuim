using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameJolt.API;
using GameJolt.UI;

public class GameJoltManager : MonoBehaviour {

    private GameObject loginText;

    private bool isSignedIn;

    private void Awake()
    {
        loginText = GameObject.FindWithTag("AplicadoText");
    }
	
	private void Update ()
    {
        isSignedIn = GameJoltAPI.Instance.CurrentUser != null;
        if (isSignedIn)
        {
            loginText.GetComponent<Text>().text = "Sair da conta " + GameJoltAPI.Instance.CurrentUser.Name;
        } else
        {
            loginText.GetComponent<Text>().text = "Login com GameJolt";
        }
	}

    public static void UnlockTrophy(int TrophyID)
    {
        if (GameJoltAPI.Instance.CurrentUser != null && PlayerPrefs.GetInt(GameJoltAPI.Instance.CurrentUser.Name + TrophyID.ToString()) != 1)
        {
            Trophies.Unlock(TrophyID, (bool success) => {
                if (success)
                {
                    Debug.Log("Troféu desbloqueado!");
                    PlayerPrefs.SetInt(GameJoltAPI.Instance.CurrentUser.Name + TrophyID.ToString(), 1);
                }
                else
                {
                    Debug.Log("Troféu não desbloqueado...");
                }
            });
        }
    }
}
