using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAnim : MonoBehaviour {

    private static Image sr;
    private static Roupas rps;
    private static Animator anim;

    private void Awake()
    {
        sr = GetComponent<Image>();
        rps = GameObject.FindWithTag("Roupas").GetComponent<Roupas>();
        anim = GetComponent<Animator>();
    }

    public static void SaveLoad(int sl)
    {
        if (sl == 0)
            sr.sprite = rps.salvo;
        else
            sr.sprite = rps.carregado;

        anim.Play("FadeOutSaveLoad");
    }

}
