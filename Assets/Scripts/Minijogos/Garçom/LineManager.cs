using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LineManager : MonoBehaviour {

    public int[] fila;

    public SpriteRenderer Fila1;
    public SpriteRenderer Fila2;
    public SpriteRenderer Fila3;

    public Sprite buffet;
    public Sprite dessert;
    public Sprite staff;

    public Sprite[] scrats;

    public Animator anim;

    public AudioSource sfx;
    public AudioClip certo;
    public AudioClip errado;

    public SpriteRenderer clock;
    public Sprite redClock;

    public int credsGanhos;

    private void Start()
    {
        fila = new int[4];
        scrats = new Sprite[3];

        scrats[0] = buffet;
        scrats[1] = dessert;
        scrats[2] = staff;

        fila[0] = Random.Range(0, 3);
        fila[1] = Random.Range(0, 3);
        fila[2] = Random.Range(0, 3);
        fila[3] = Random.Range(0, 3);

        Fila1 = GameObject.FindWithTag("Fila1").GetComponent<SpriteRenderer>();
        Fila2 = GameObject.FindWithTag("Fila2").GetComponent<SpriteRenderer>();
        Fila3 = GameObject.FindWithTag("Fila3").GetComponent<SpriteRenderer>();

        anim.SetInteger("Idle", fila[0]);
        Fila2.sprite = scrats[fila[1]];
        Fila3.sprite = scrats[fila[2]];

    }

    private void Update()
    {
        if (clock.sprite == redClock)
        {
            EndOfGame();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (fila[0] == 0)
            {
                UpdateSprites();
            } else
            {
                Wrong();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (fila[0] == 1)
            {
                UpdateSprites();
            }
            else
            {
                Wrong();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (fila[0] == 2)
            {
                UpdateSprites();
            }
            else
            {
                Wrong();
            }
        }
    }

    public void UpdateSprites()
    {
        anim.PlayInFixedTime(fila[0] + "Go");

        fila[0] = fila[1];
        fila[1] = fila[2];
        fila[2] = fila[3];
        fila[3] = Random.Range(0, 3);

        anim.SetInteger("Idle", fila[0]);
        Fila2.sprite = scrats[fila[1]];
        Fila3.sprite = scrats[fila[2]];

        sfx.PlayOneShot(certo);
        credsGanhos += 4;
    }

    public void Wrong()
    {
        credsGanhos -= 2;
        if (credsGanhos < 0)
            credsGanhos = 0;
        Debug.Log("Errou!!!");
        sfx.PlayOneShot(errado);
    }

    public void EndOfGame()
    {
        Debug.Log("Fim de jogo! Você ganhou " + credsGanhos + " creds!");
        CredsSystem.credsTotal += credsGanhos;
        EndGameManager.credsGanhos = credsGanhos;
        EndGameManager.gameID = 0;
        SceneManager.LoadScene("EndGame");
    }

}
