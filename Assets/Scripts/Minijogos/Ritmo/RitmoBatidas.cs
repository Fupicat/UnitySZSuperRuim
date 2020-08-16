using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitmoBatidas : MonoBehaviour {

    public float bpm;
    public bool Começo;

	void Start () {
        bpm = bpm / 60f;
	}
	
	void Update () {
		
        if (!Começo)
        {
            //if (Input.anyKeyDown)
            //{
                //Começo = true;
            //}
        }
        else
        {
            transform.position -= new Vector3(0f, bpm * Time.deltaTime, 0f);
        }

	}
}
