using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour {

    public static int gameID;

    public Text título;
    public Text comoJogar;
    public Text CJTítulo;
    public Image telaCJ;
    public Image voltar;
    public Text voltarText;

    string[] jogos = { "Erro", "WorkGarçom" };
    string[] nomes = { "Erro: Referência faltando", "Garçom" };
    string[] instruções =
    {
        "Erro: Referência faltando",
        "Clientes virão em uma fila, e cada um quer uma coisa. \n Aperte as teclas A, S e D para dividí-los, de acordo com o chapéu que cada um está usando."
    };
    string[] sair =
    {
        "Erro",
        "WalkRestaurante"
    };

	public void Start () {
        título.text = nomes[gameID];
        comoJogar.text = instruções[gameID];

        telaCJ.enabled = false;
        CJTítulo.enabled = false;
        comoJogar.enabled = false;
        voltar.enabled = false;
        voltarText.enabled = false;
    }

    public void ComoJogar ()
    {
        telaCJ.enabled = true;
        CJTítulo.enabled = true;
        comoJogar.enabled = true;
        voltar.enabled = true;
        voltarText.enabled = true;
    }

    public void Voltar()
    {
        telaCJ.enabled = false;
        CJTítulo.enabled = false;
        comoJogar.enabled = false;
        voltar.enabled = false;
        voltarText.enabled = false;
    }

    public void Jogar()
    {
        SceneManager.LoadScene(jogos[gameID]);
    }

    public void Sair()
    {
        SceneManager.LoadScene(sair[gameID]);
    }
}
