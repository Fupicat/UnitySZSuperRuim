using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameJolt.UI;
using GameJolt.API;
using System.Linq;

public class Button : MonoBehaviour {

	//Está com problemas para decidir que script bugado usar? Escolha o Button.cs!! "A melhor (?) solução para qualquer botão!" (tm)

	private GameObject Cabelo;
	private GameObject Roupa;
	private GameObject Calça;
	private GameObject Luva1;
	private GameObject Luva2;
	private GameObject Sapato1;
	private GameObject Sapato2;

	public string Lugar;
	public Texture2D cursorTexture;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;
    public static bool podePegar = true;
    
    //Tipos de botão

    public bool goSomewhere = true; //Ir a alguma cena
    public bool goLastScene; //Ir à cena anterior

    public bool adicionarCreds; //Adicionar Creds à conta do usuário
    public int CredsAAdicionar; //Quantos creds a adicionar

    public bool resetPlanetDir; //Resetar a direção do planeta

    public bool Inventário; //Esse botão é um botão do inventário
    public string InvParte; //A parte do corpo que esse botão de inventário deve mudar
    public GameObject aplicado;

    public int ProdutoRoupas; //Produto na Loja de Roupas
    public Sprite ProdutoComida; //Produto no Restaurante
    public int price; //O preço desse produto

    public bool NPC; //É um NPC clicável

    public bool tocarSom; //Toca um som
    private AudioSource caixaDeSom; //O AudioSource
    public AudioClip Som; //O som em si

    public bool startGame; //Inicia um jogo
    public int gameID; //ID do jogo

    //Configurações

    public TextBoxManager txtBox;

	public Image black;
	public Animator anim;

	public Sprite Normal;
	public Sprite Hover;

    private Animator credAnimation;
    private Text credText;

	void Awake() {

        txtBox = FindObjectOfType<TextBoxManager>();

        if (GameObject.FindWithTag("CredAnim") != null)
        {
            credAnimation = GameObject.FindWithTag("CredAnim").GetComponent<Animator>();
            credText = GameObject.FindWithTag("AplicadoText").GetComponent<Text>();
        }

        if (GameObject.FindWithTag("SFX") != null)
            caixaDeSom = GameObject.FindWithTag("SFX").GetComponent<AudioSource>();

        if (GameObject.FindWithTag("Cabeça") != null)
        {
            Cabelo = GameObject.FindWithTag("Cabeça");
            Roupa = GameObject.FindWithTag("Roupa");
            Calça = GameObject.FindWithTag("Calça");
            Luva1 = GameObject.FindGameObjectsWithTag("Luva")[0];
            Luva2 = GameObject.FindGameObjectsWithTag("Luva")[1];
            Sapato1 = GameObject.FindGameObjectsWithTag("Sapato")[0];
            Sapato2 = GameObject.FindGameObjectsWithTag("Sapato")[1];
        }

        aplicado = GameObject.FindWithTag("AplicadoImage");

        var gos = GameObject.FindGameObjectWithTag("Fade");
        if (gos != null)
        {
            black = GameObject.FindWithTag("Fade").GetComponent<Image>();
            anim = GameObject.FindWithTag("Fade").GetComponent<Animator>();
        } else {
            black = null;
            anim = null;
        }

    }

	void OnMouseEnter()
    {
        if (txtBox == null || txtBox.planet.canMove)
        {
            if (Hover != null)
                GetComponent<SpriteRenderer>().sprite = Hover;

            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }

	void OnMouseExit() {

        if (Normal != null)
		    GetComponent<SpriteRenderer>().sprite = Normal;

		Cursor.SetCursor (null, hotSpot, cursorMode);

    }

	void OnMouseDown ()
    {
        if (txtBox == null || txtBox.planet.canMove)
        {
            ButtonOptions();
        } 
	}

	IEnumerator Fading() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		Cursor.SetCursor (null, hotSpot, cursorMode);
		SceneManager.LoadScene (Lugar);

	}

	IEnumerator FadingLast() {

		anim.SetBool ("Fade", true);
		yield return new WaitUntil (() => black.color.a == 1);
		Cursor.SetCursor (null, hotSpot, cursorMode);
		SceneManager.LoadScene (PlanetaControle.CurrentPlanet);

	}

    public void ButtonOptions()
    {
        if (tocarSom)
        {
            caixaDeSom.PlayOneShot(Som);
        }

        if (adicionarCreds)
        {
            if (SceneManager.GetActiveScene().name == "Djangia")
            {
                if (podePegar)
                {
                    caixaDeSom.PlayOneShot(Som);
                    podePegar = false;
                    CredsSystem.credsTotal += CredsAAdicionar;
                    credText.text = "+" + CredsAAdicionar.ToString() + " ¢";
                    credAnimation.Play("CredAnimation");
                }
            } else
            {
                caixaDeSom.PlayOneShot(Som);
                CredsSystem.credsTotal += CredsAAdicionar;
                credText.text = "+" + CredsAAdicionar.ToString() + " ¢";
                credAnimation.Play("CredAnimation");
            }
        }

        if (resetPlanetDir)
            PlanetaControle.PlanetDirection = Vector3.zero;

        if (Inventário)
        {
            if (InvParte == "Cabelo+")
                Cabelo.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(0, 1).sprite;
            if (InvParte == "Cabelo-")
                Cabelo.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(0, -1).sprite;
            if (InvParte == "Roupa+")
                Roupa.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(1, 1).sprite;
            if (InvParte == "Roupa-")
                Roupa.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(1, -1).sprite;
            if (InvParte == "Calça+")
                Calça.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(2, 1).sprite;
            if (InvParte == "Calça-")
                Calça.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(2, -1).sprite;
            if (InvParte == "Luva+")
            {
                Luva1.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(3, 1).sprite;
                Luva2.GetComponent<SpriteRenderer>().sprite = Luva1.GetComponent<SpriteRenderer>().sprite;
            }
            if (InvParte == "Luva-")
            {
                Luva1.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(3, -1).sprite;
                Luva2.GetComponent<SpriteRenderer>().sprite = Luva1.GetComponent<SpriteRenderer>().sprite;
            }
            if (InvParte == "Sapato+")
            {
                Sapato1.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(4, 1).sprite;
                Sapato2.GetComponent<SpriteRenderer>().sprite = Sapato1.GetComponent<SpriteRenderer>().sprite;
            }
            if (InvParte == "Sapato-")
            {
                Sapato1.GetComponent<SpriteRenderer>().sprite = Cabelo.GetComponent<SkinManager>().NextRoupa(4, -1).sprite;
                Sapato2.GetComponent<SpriteRenderer>().sprite = Sapato1.GetComponent<SpriteRenderer>().sprite;
            }
            if (InvParte == "Usar")
            {
                SkinManager.CabeçaUsando = SkinManager.GetRoupaBySprite(Cabelo.GetComponent<SpriteRenderer>().sprite);
                SkinManager.RoupaUsando = SkinManager.GetRoupaBySprite(Roupa.GetComponent<SpriteRenderer>().sprite);
                SkinManager.CalçaUsando = SkinManager.GetRoupaBySprite(Calça.GetComponent<SpriteRenderer>().sprite);
                SkinManager.LuvaUsando = SkinManager.GetRoupaBySprite(Luva1.GetComponent<SpriteRenderer>().sprite);
                SkinManager.SapatoUsando = SkinManager.GetRoupaBySprite(Sapato1.GetComponent<SpriteRenderer>().sprite);

                aplicado.GetComponent<Animator>().Play("AplicadoFadeOut");
            }

        }

        if (ProdutoRoupas != 0)
        {
            if (CredsSystem.credsTotal >= price)
            {
                SkinManager.Roupa item = SkinManager.All[ProdutoRoupas];

                if (SkinManager.Inventory.Contains(item))
                {
                    Debug.Log("Você já tem esse item.");
                }
                else
                {
                    SkinManager.Inventory.Add(item);

                    CredsSystem.credsTotal -= price;
                    Debug.Log("Comprado!");
                }
            }
            else
            {
                Debug.Log("Não tem Creds o suficiente");
            }

        }

        if (ProdutoComida != null)
        {
            if (CredsSystem.credsTotal >= price)
            {

                CredsSystem.credsTotal -= price;
                ComidaControle.quantoComido = 0;
                ComidaControle.Comida = ProdutoComida;
                Debug.Log("Comprado!");

            }
            else
            {
                Debug.Log("Não tem Creds o suficiente");
            }
        }

        if (NPC)
        {
            GetComponent<ActivateTextAtLine>().StartSpeaking();
        }

        if (startGame)
        {
            Lugar = "MenuGame";
            StartGameManager.gameID = gameID;
            StartCoroutine(Fading());
        }

        if (goSomewhere)
        {
            StartCoroutine(Fading());
        }

        if (goLastScene)
            StartCoroutine(FadingLast());
    }

}