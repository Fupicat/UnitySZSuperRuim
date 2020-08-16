using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasaRender : MonoBehaviour {

    public class Decor
    {
        public Sprite sprite;
        public string nome;
        public int tipo;
        public AudioClip música;

        public Decor(Sprite spr, string str, int i, AudioClip ac)
        {
            sprite = spr;
            nome = str;
            tipo = i; // CoDeMu: Cor, decoração, música.
            música = ac;
        }
    }

    private int itemNumAtual = 0;

    // Partes do Planeta
    [HideInInspector] public SpriteRenderer Planeta;
    [HideInInspector] public SpriteRenderer Slot1;
    [HideInInspector] public SpriteRenderer Slot2;
    [HideInInspector] public SpriteRenderer Slot3;
    [HideInInspector] public SpriteRenderer Slot4;
    [HideInInspector] public SpriteRenderer Slot5;
    [HideInInspector] public SpriteRenderer Slot6;
    [HideInInspector] public SpriteRenderer Slot7;
    [HideInInspector] public SpriteRenderer Slot8;
    [HideInInspector] public SpriteRenderer Slot9;
    [HideInInspector] public BGMusic BGM;
    public Canvas Editor;
    public Canvas UI;

    private Image CorUI;
    private Image DiscoUI;
    private Image S1UI;
    private Image S2UI;
    private Image S3UI;
    private Image S4UI;
    private Image S5UI;
    private Image S6UI;
    private Image S7UI;
    private Image S8UI;
    private Image S9UI;
    private Roupas rps;

	//Usando
	public static Decor CasaCor;
	public static Decor CasaMúsica;
	public static Decor CasaSlot1;
	public static Decor CasaSlot2;
	public static Decor CasaSlot3;
	public static Decor CasaSlot4;
	public static Decor CasaSlot5;
	public static Decor CasaSlot6;
	public static Decor CasaSlot7;
	public static Decor CasaSlot8;
	public static Decor CasaSlot9;

    public static List<Decor> All = new List<Decor>();

	void Awake () {

        EditorClose();

		Planeta = GameObject.Find ("Planeta").GetComponent<SpriteRenderer>();
		Slot1 = GameObject.Find ("Slot1").GetComponent<SpriteRenderer>();
		Slot2 = GameObject.Find ("Slot2").GetComponent<SpriteRenderer>();
		Slot3 = GameObject.Find ("Slot3").GetComponent<SpriteRenderer>();
		Slot4 = GameObject.Find ("Slot4").GetComponent<SpriteRenderer>();
		Slot5 = GameObject.Find ("Slot5").GetComponent<SpriteRenderer>();
		Slot6 = GameObject.Find ("Slot6").GetComponent<SpriteRenderer>();
		Slot7 = GameObject.Find ("Slot7").GetComponent<SpriteRenderer>();
		Slot8 = GameObject.Find ("Slot8").GetComponent<SpriteRenderer>();
		Slot9 = GameObject.Find ("Slot9").GetComponent<SpriteRenderer>();
		BGM = FindObjectOfType<BGMusic> ();

        CorUI = GameObject.FindWithTag("AplicadoText").GetComponent<Image>();
        DiscoUI = GameObject.FindWithTag("AplicadoImage").GetComponent<Image>();
        S1UI = GameObject.Find("S1UI").GetComponent<Image>();
        S2UI = GameObject.Find("S2UI").GetComponent<Image>();
        S3UI = GameObject.Find("S3UI").GetComponent<Image>();
        S4UI = GameObject.Find("S4UI").GetComponent<Image>();
        S5UI = GameObject.Find("S5UI").GetComponent<Image>();
        S6UI = GameObject.Find("S6UI").GetComponent<Image>();
        S7UI = GameObject.Find("S7UI").GetComponent<Image>();
        S8UI = GameObject.Find("S8UI").GetComponent<Image>();
        S9UI = GameObject.Find("S9UI").GetComponent<Image>();
        rps = GameObject.FindWithTag("Roupas").GetComponent<Roupas>();

        LoadDecors();

        if (CasaCor == null)
        {
            CasaCor = All[0];
            CasaMúsica = All[1];
            CasaSlot1 = All[2];
            CasaSlot2 = All[2];
            CasaSlot3 = All[2];
            CasaSlot4 = All[2];
            CasaSlot5 = All[2];
            CasaSlot6 = All[2];
            CasaSlot7 = All[2];
            CasaSlot8 = All[2];
            CasaSlot9 = All[2];
        }

        Planeta.sprite = CasaCor.sprite;
        CorUI.sprite = CasaCor.sprite;
        BGM.ChangeBGM(CasaMúsica.música);
        DiscoUI.sprite = rps.D1;
        Slot1.sprite = CasaSlot1.sprite;
        S1UI.sprite = CasaSlot1.sprite;

        Slot2.sprite = CasaSlot2.sprite;
        S2UI.sprite = CasaSlot2.sprite;

        Slot3.sprite = CasaSlot3.sprite;
        S3UI.sprite = CasaSlot3.sprite;

        Slot4.sprite = CasaSlot4.sprite;
        S4UI.sprite = CasaSlot4.sprite;

        Slot5.sprite = CasaSlot5.sprite;
        S5UI.sprite = CasaSlot5.sprite;

        Slot6.sprite = CasaSlot6.sprite;
        S6UI.sprite = CasaSlot6.sprite;

        Slot7.sprite = CasaSlot7.sprite;
        S7UI.sprite = CasaSlot7.sprite;

        Slot8.sprite = CasaSlot8.sprite;
        S8UI.sprite = CasaSlot8.sprite;

        Slot9.sprite = CasaSlot9.sprite;
        S9UI.sprite = CasaSlot9.sprite;
    }

	void Update () {

		if (Input.GetKeyDown (KeyCode.Q))
            NextCor();

		if (Input.GetKeyDown (KeyCode.E))
            NextMúsica();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            NextS1();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            NextS2();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            NextS3();

        if (Input.GetKeyDown(KeyCode.Alpha4))
            NextS4();

        if (Input.GetKeyDown(KeyCode.Alpha5))
            NextS5();

        if (Input.GetKeyDown(KeyCode.Alpha6))
            NextS6();

        if (Input.GetKeyDown(KeyCode.Alpha7))
            NextS7();

        if (Input.GetKeyDown(KeyCode.Alpha8))
            NextS8();

        if (Input.GetKeyDown(KeyCode.Alpha9))
            NextS9();

    }

    public void NextCor()
    {
        CasaCor = NextDecor(0);
        Planeta.sprite = CasaCor.sprite;
        CorUI.sprite = CasaCor.sprite;
    }

    public void NextMúsica()
    {
        CasaMúsica = NextDecor(2);
        BGM.ChangeBGM(CasaMúsica.música);
        Sprite[] discos = new Sprite[] { rps.D1, rps.D2, rps.D3, rps.D4, rps.D5, rps.D6, rps.D7, rps.D8 };
        int index = Random.Range(0, 7);
        DiscoUI.sprite = discos[index];
    }

    public void NextS1()
    {
        CasaSlot1 = NextDecor(1);
        Slot1.sprite = CasaSlot1.sprite;
        S1UI.sprite = CasaSlot1.sprite;
    }

    public void NextS2()
    {
        CasaSlot2 = NextDecor(1);
        Slot2.sprite = CasaSlot2.sprite;
        S2UI.sprite = CasaSlot2.sprite;
    }

    public void NextS3()
    {
        CasaSlot3 = NextDecor(1);
        Slot3.sprite = CasaSlot3.sprite;
        S3UI.sprite = CasaSlot3.sprite;
    }

    public void NextS4()
    {
        CasaSlot4 = NextDecor(1);
        Slot4.sprite = CasaSlot4.sprite;
        S4UI.sprite = CasaSlot4.sprite;
    }

    public void NextS5()
    {
        CasaSlot5 = NextDecor(1);
        Slot5.sprite = CasaSlot5.sprite;
        S5UI.sprite = CasaSlot5.sprite;
    }

    public void NextS6()
    {
        CasaSlot6 = NextDecor(1);
        Slot6.sprite = CasaSlot6.sprite;
        S6UI.sprite = CasaSlot6.sprite;
    }

    public void NextS7()
    {
        CasaSlot7 = NextDecor(1);
        Slot7.sprite = CasaSlot7.sprite;
        S7UI.sprite = CasaSlot7.sprite;
    }

    public void NextS8()
    {
        CasaSlot8 = NextDecor(1);
        Slot8.sprite = CasaSlot8.sprite;
        S8UI.sprite = CasaSlot8.sprite;
    }

    public void NextS9()
    {
        CasaSlot9 = NextDecor(1);
        Slot9.sprite = CasaSlot9.sprite;
        S9UI.sprite = CasaSlot9.sprite;
    }

    public Decor NextDecor(int tipo)
    {
        List<Decor> decorsDesteTipo = new List<Decor>();
        foreach (Decor item in All)
        {
            if (item.tipo == tipo)
                decorsDesteTipo.Add(item);
        }

        ++itemNumAtual;
        if (itemNumAtual > decorsDesteTipo.Count - 1)
            itemNumAtual = 0;

        return decorsDesteTipo[itemNumAtual];
    }

    private static void AddToAll(Sprite spr, string str, int i, AudioClip ac = null)
    {
        All.Add(new Decor(spr, str, i, ac));
    }

    public static Decor GetDecorBySprite(Sprite spr)
    {
        Decor rp = new Decor(null, "Erro", 0, null);
        foreach (Decor item in All)
        {
            if (spr == item.sprite)
            {
                rp = item;
            }
        }
        return rp;
    }

    public static int GetDecorID(Decor rp)
    {
        int id = 0;
        foreach (Decor item in All)
        {
            if (rp.nome == item.nome)
            {
                id = All.IndexOf(item);
            }
        }
        return id;
    }

    public void EditorOpen()
    {
        UI.enabled = false;
        Editor.enabled = true;
    }

    public void EditorClose()
    {
        UI.enabled = true;
        Editor.enabled = false;
    }

    public static void LoadDecors()
    {
        if (All.Count == 0) // CoDeMu: Cor, decoração, música.
        {
            Roupas rps = GameObject.FindWithTag("Roupas").GetComponent<Roupas>();

            AddToAll(rps.PVermelho, "Pedras Vulcânicas", 0);
            AddToAll(null, "Disco", 2, rps.Disco);
            AddToAll(rps.PVazio, "Vazio", 1);

            AddToAll(rps.PLaranja, "Suco de Laranja Endurecido", 0);
            AddToAll(rps.PAmarelo, "Pedras Solares", 0);
            AddToAll(rps.PVerdeClaro, "Grama de Limonada", 0);
            AddToAll(rps.PVerde, "Grama", 0);
            AddToAll(rps.PCiano, "Água Endurecida", 0);
            AddToAll(rps.PAzul, "Gelo", 0);
            AddToAll(rps.PRosa, "Chiclete", 0);
            AddToAll(rps.PRoxo, "Ametistas", 0);
            AddToAll(rps.PMarrom, "Chocolate", 0);
            AddToAll(rps.PBranco, "Neve", 0);
            AddToAll(rps.PPreto, "Carvão", 0);

            AddToAll(rps.PCasa, "Casa", 1);
            AddToAll(rps.PCachoeira, "Cachoeira", 1);
            AddToAll(rps.PArbusto, "Arbustos", 1);

            AddToAll(null, "Violão", 2, rps.Guitar);
            AddToAll(null, "Piano", 2, rps.Jazz);
            AddToAll(null, "Segurança", 2, rps.Safe);
        }
    }

}
