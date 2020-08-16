using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmoManager : MonoBehaviour {

    public AudioSource mus;
    public bool tocar;
    public RitmoBatidas rb;

    public static RitmoManager instance;

	void Start ()
    {
        instance = this;
	}
	
	void Update ()
    {
		if (!tocar)
        {
            if (Input.anyKeyDown)
            {
                tocar = true;
                rb.Começo = true;
                mus.Play();
            }
        }
	}

    public void NoteHit()
    {
        Debug.Log(":DDDD");
    }

    public void NoteMiss()
    {
        Debug.Log(">:((((");
    }
}
