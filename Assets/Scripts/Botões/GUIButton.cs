using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameJolt;
using GameJolt.UI;
using GameJolt.API;

public class GUIButton : MonoBehaviour {

    public Image black;
    public Animator anim;

    public int credsToAdd;
    public string back;

    private bool LoggedIn;

    private Animator credAnimation;
    private Text credText;

    private void Awake()
    {
        if (GameObject.FindWithTag("CredAnim") != null)
        {
            credAnimation = GameObject.FindWithTag("CredAnim").GetComponent<Animator>();
            credText = GameObject.FindWithTag("AplicadoText").GetComponent<Text>();
        }

        var gos = GameObject.FindGameObjectWithTag("Fade");
        if (gos != null)
        {
            black = GameObject.FindWithTag("Fade").GetComponent<Image>();
            anim = GameObject.FindWithTag("Fade").GetComponent<Animator>();
        } else
        {
            black = null;
            anim = null;
        }
    }

    public void GameGarçom()
    {
        StartGameManager.gameID = 1;
        StartCoroutine(Fading("MenuGame"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlanetaCentral()
    {
        StartCoroutine(Fading("PlanetaCentral"));
    }

    public void Continuar()
    {
        GJSave.GJLoad();
        GJSave.GJLoad();
        GJSave.GJLoad();
    }

    public void GameJoltLogin()
    {
        var isSignedIn = GameJoltAPI.Instance.CurrentUser != null;
        if (isSignedIn)
        {
            GameJoltAPI.Instance.CurrentUser.SignOut();
        } else
        {
            GameJoltUI.Instance.ShowSignIn();
        }
    }

    public void AddCreds()
    {
        CredsSystem.credsTotal += credsToAdd;
        credText.text = "+" + credsToAdd.ToString() + " ¢";
        credAnimation.Play("CredAnimation");
        if (back != null)
        {
            StartCoroutine(Fading(back));
        }
    }

    public void LastScene()
    {
        StartCoroutine(Fading(PlanetaControle.CurrentPlanet));
    }

    public void ExitRadar()
    {
        if (MissionManager.radar.enabled)
            MissionManager.ExitRadar();
        else
            StartCoroutine(Fading("PlanetaCentral"));
    }

    IEnumerator Fading(string Lugar)
    {
        if (black != null)
        {
            anim.SetBool("Fade", true);
            yield return new WaitUntil(() => black.color.a == 1);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        SceneManager.LoadScene(Lugar);

    }

}
