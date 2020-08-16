using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour {

    public class Roupa
    {
        public Sprite sprite;
        public string nome;
        public int tipo;

        public Roupa(Sprite spr, string str, int i)
        {
            sprite = spr;
            nome = str;
            tipo = i; // CaRaCoLeS: Cabeça, roupa, calça, luva, sapato
        }
    }

    private int itemNumAtual = 0;

    // Partes do corpo
    [HideInInspector] public SpriteRenderer cabeça;
    [HideInInspector] public SpriteRenderer roupa;
    [HideInInspector] public SpriteRenderer calça;
    [HideInInspector] public SpriteRenderer luva;
    [HideInInspector] public SpriteRenderer luva2;
    [HideInInspector] public SpriteRenderer sapato;
    [HideInInspector] public SpriteRenderer sapato2;

    private Roupas rps;

    //Usando
    public static Roupa CabeçaUsando;
    public static Roupa RoupaUsando;
    public static Roupa CalçaUsando;
    public static Roupa LuvaUsando;
    public static Roupa SapatoUsando;

    public static List<Roupa> All = new List<Roupa>();

    public static List<Roupa> Inventory = new List<Roupa>();

    private void Awake()
    {
        rps = GameObject.FindWithTag("Roupas").GetComponent<Roupas>();

        cabeça = GameObject.FindWithTag("Cabeça").GetComponent<SpriteRenderer>();
        roupa = GameObject.FindWithTag("Roupa").GetComponent<SpriteRenderer>();
        calça = GameObject.FindWithTag("Calça").GetComponent<SpriteRenderer>();
        luva = GameObject.FindGameObjectsWithTag("Luva")[0].GetComponent<SpriteRenderer>();
        luva2 = GameObject.FindGameObjectsWithTag("Luva")[1].GetComponent<SpriteRenderer>();
        sapato = GameObject.FindGameObjectsWithTag("Sapato")[0].GetComponent<SpriteRenderer>();
        sapato2 = GameObject.FindGameObjectsWithTag("Sapato")[1].GetComponent<SpriteRenderer>();

        // Load all clothes
        if (All.Count == 0) // CaRaCoLeS: Cabelo, Roupa, Calça, Luva, Sapato
        {
            AddToAll(rps.Careca, "Careca", 0);                                  //0
            AddToAll(rps.UniformeLaranja, "Uniforme Laranja", 1);               //1
            AddToAll(rps.Dupla, "Calça Dupla", 2);                              //2
            AddToAll(rps.LuvaBranca, "Luvas Brancas", 3);                       //3
            AddToAll(rps.SapatoMarrom, "Sapatos Marrons", 4);                   //4
            AddToAll(rps.CurtoCastanho, "Cabelo Curto", 0);                     //5
            AddToAll(rps.UniformeRoxo, "Uniforme Roxo", 1);                     //6
            AddToAll(rps.Jeans, "Jeans", 2);                                    //7
            AddToAll(rps.LuvaPreta, "Luvas Pretas", 3);                         //8
            AddToAll(rps.TênisAzul, "Tênis Azuis", 4);                          //9
            AddToAll(rps.Casual, "Roupa Casual Vermelha", 1);                   //10
        }

        // Set inventory defaults
        if (Inventory.Count == 0)
        {
            Inventory.Add(new Roupa(rps.Careca, "Careca", 0));
            Inventory.Add(new Roupa(rps.UniformeLaranja, "Uniforme Laranja", 1));
            Inventory.Add(new Roupa(rps.Dupla, "Calça Dupla", 2));
            Inventory.Add(new Roupa(rps.LuvaBranca, "Luvas Brancas", 3));
            Inventory.Add(new Roupa(rps.SapatoMarrom, "Sapatos Marrons", 4));
        }

        // Set variables to defaults
        if (CabeçaUsando == null)
        {
            CabeçaUsando = Inventory[0];
            RoupaUsando = Inventory[1];
            CalçaUsando = Inventory[2];
            LuvaUsando = Inventory[3];
            SapatoUsando = Inventory[4];
        }

        // Set defaults
        cabeça.sprite = CabeçaUsando.sprite;
        roupa.sprite = RoupaUsando.sprite;
        calça.sprite = CalçaUsando.sprite;
        luva.sprite = LuvaUsando.sprite;
        luva2.sprite = LuvaUsando.sprite;
        sapato.sprite = SapatoUsando.sprite;
        sapato2.sprite = SapatoUsando.sprite;
    }

    public static int GetRoupaID(Roupa rp)
    {
        int id = 0;
        foreach (Roupa item in All)
        {
            if (rp.nome == item.nome)
            {
                id = All.IndexOf(item);
            }
        }
        return id;
    }

    public static Roupa GetRoupaBySprite(Sprite spr)
    {
        Roupa rp = new Roupa(null, "Erro", 0);
        foreach (Roupa item in All)
        {
            if (spr == item.sprite)
            {
                rp = item;
            }
        }
        return rp;
    }

    public void AddToInventory(Roupa rp)
    {
        Inventory.Add(rp);
    }

    private void AddToAll(Sprite spr, string str, int i)
    {
        All.Add(new Roupa(spr, str, i));
    }

    public Roupa NextRoupa(int tipo, int mais)
    {
        List<Roupa> roupasDesteTipo = new List<Roupa>();
        foreach (Roupa item in Inventory)
        {
            if (item.tipo == tipo)
                roupasDesteTipo.Add(item);
        }

        itemNumAtual = itemNumAtual + 1 * mais;
        if (itemNumAtual > roupasDesteTipo.Count -1)
        {
            itemNumAtual = 0;
        } else if (itemNumAtual < 0)
        {
            itemNumAtual = roupasDesteTipo.Count - 1;
        }

        return roupasDesteTipo[itemNumAtual];
    }

}
