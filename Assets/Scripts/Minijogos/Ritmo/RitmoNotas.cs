using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmoNotas : MonoBehaviour {

    public bool PodeApertar;

    public KeyCode tecla;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(tecla))
        {
            if (PodeApertar)
            {
                gameObject.SetActive(false);

                RitmoManager.instance.NoteHit();
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            PodeApertar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            PodeApertar = false;

            RitmoManager.instance.NoteMiss();
        }
    }

}
