using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmoBotões : MonoBehaviour {

    private SpriteRenderer sr;
    public Sprite offImg;
    public Sprite onImg;

    public KeyCode tecla;

	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
        if (Input.GetKeyDown(tecla))
        {
            sr.sprite = onImg;
        }

        if (Input.GetKeyUp(tecla))
        {
            sr.sprite = offImg;
        }
	}
}
