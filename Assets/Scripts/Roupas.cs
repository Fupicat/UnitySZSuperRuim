using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roupas : MonoBehaviour {

	//Cabelo
	public Sprite Careca;
	public Sprite CurtoCastanho;

	//Roupas
	public Sprite UniformeLaranja;
	public Sprite UniformeRoxo;
	public Sprite Casual;

	//Calças
	public Sprite Dupla;
	public Sprite Jeans;

	//Luvas
	public Sprite LuvaBranca;
	public Sprite LuvaPreta;

	//Sapatos
	public Sprite SapatoMarrom;
	public Sprite TênisAzul;

    //Outros
    public Sprite salvo;
    public Sprite carregado;

    //Cores Planeta
    public Sprite PVermelho;
    public Sprite PLaranja;
    public Sprite PAmarelo;
    public Sprite PVerdeClaro;
    public Sprite PVerde;
    public Sprite PCiano;
    public Sprite PAzul;
    public Sprite PRoxo;
    public Sprite PRosa;
    public Sprite PMarrom;
    public Sprite PPreto;
    public Sprite PBranco;

    //Decorações Planeta
    public Sprite PCasa;
    public Sprite PCachoeira;
    public Sprite PArbusto;
    public Sprite PVazio;

    //Discos
    public Sprite D1;
    public Sprite D2;
    public Sprite D3;
    public Sprite D4;
    public Sprite D5;
    public Sprite D6;
    public Sprite D7;
    public Sprite D8;

    //Músicas
    public AudioClip Disco;
    public AudioClip Guitar;
    public AudioClip Jazz;
    public AudioClip Safe;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
