using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Senha : MonoBehaviour {

    public string senha;
    public string resposta;
    public string feedback;

    public Text instruções;
    public Text respostaTexto;
    public Text feedbackTexto;
    public Text vidasTexto;

    public int vidas;

    public AudioSource som;

    public AudioClip teclaSom;
    public AudioClip feedbackSom;
    public AudioClip certoSom;
    public AudioClip perdeuSom;

    public string[] cars = new string[]
    {
        "w", "a", "s", "d"
    };

	void Start ()
    {
        GerarSenha();
    }
	
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.W))
        {
            resposta = resposta + "w";
            som.pitch = Random.Range(0.7f, 1.5f);
            som.PlayOneShot(teclaSom);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            resposta = resposta + "a";
            som.pitch = Random.Range(0.7f, 1.5f);
            som.PlayOneShot(teclaSom);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            resposta = resposta + "s";
            som.pitch = Random.Range(0.7f, 1.5f);
            som.PlayOneShot(teclaSom);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            resposta = resposta + "d";
            som.pitch = Random.Range(0.7f, 1.5f);
            som.PlayOneShot(teclaSom);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            resposta = "";
            som.pitch = Random.Range(0.7f, 1.5f);
            som.PlayOneShot(teclaSom);
        }
        if (Input.GetKeyDown(KeyCode.Return))
            CompararResposta();

        if (resposta.Length > 4)
            resposta = resposta[1].ToString() + resposta[2].ToString() + resposta[3].ToString() + resposta[4].ToString();

        respostaTexto.text = resposta.ToUpper();
        vidasTexto.text = "Vidas: " + vidas.ToString();

        if (vidas == 0)
        {
            Debug.Log("Você perdeu. Senha reiniciada.");
            GerarSenha();
            vidas = 10;
            som.pitch = 1;
            som.PlayOneShot(perdeuSom);
        }
    }

    void CompararResposta()
    {
        if (resposta.Length != 4)
        {
            Debug.Log("Senha precisa ter 4 caracteres.");
            som.pitch = 1;
            som.PlayOneShot(perdeuSom);
        }
        else
        {
            if (resposta == senha)
            {
                feedback = "VVVV";
                feedbackTexto.text = feedback;
                instruções.text = "Senha correta: Acesso garantido";
                som.pitch = 1;
                som.PlayOneShot(certoSom);
            }
            else
            {
                feedback = "XXXX";
                if (senha.Contains(resposta[0].ToString())) //Se a senha contém a letra na posição 0
                {
                    feedback = "OXXX";                      //A letra existe na senha
                    if (senha[0] == resposta[0])            //Se a letra estiver no lugar certo na senha
                        feedback = "VXXX";                  //A letra está no lugar correto
                }

                if (senha.Contains(resposta[1].ToString())) //Etc.
                {
                    feedback = feedback[0].ToString() + "OXX";
                    if (senha[1] == resposta[1])
                        feedback = feedback[0].ToString() + "VXX";
                }

                if (senha.Contains(resposta[2].ToString()))
                {
                    feedback = feedback[0].ToString() + feedback[1].ToString() + "OX";
                    if (senha[2] == resposta[2])
                        feedback = feedback[0].ToString() + feedback[1].ToString() + "VX";
                }

                if (senha.Contains(resposta[3].ToString()))
                {
                    feedback = feedback[0].ToString() + feedback[1].ToString() + feedback[2].ToString() + "O";
                    if (senha[3] == resposta[3])
                        feedback = feedback[0].ToString() + feedback[1].ToString() + feedback[2].ToString() + "V";
                }

                feedbackTexto.text = feedback;
                vidas -= 1;
                som.pitch = Random.Range(0.7f, 1.5f);
                som.PlayOneShot(feedbackSom);
            }
        }
    }

    void GerarSenha()
    {
        senha = cars[Random.Range(0, 3)] + cars[Random.Range(0, 3)] + cars[Random.Range(0, 3)] + cars[Random.Range(0, 3)];
    }
}
