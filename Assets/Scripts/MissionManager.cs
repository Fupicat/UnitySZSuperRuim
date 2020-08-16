using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour {

    public static Image radar;
    private static GameObject[] missões;

    private void Awake()
    {
        radar = GameObject.Find("Radar").GetComponent<Image>();
        missões = GameObject.FindGameObjectsWithTag("Fila1");

        radar.enabled = false;
        foreach (GameObject item in missões)
        {
            item.GetComponent<Image>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        radar.enabled = true;
        foreach (GameObject item in missões)
        {
            item.GetComponent<Image>().enabled = true;
        }
    }

    public static void ExitRadar()
    {
        radar.enabled = false;
        foreach (GameObject item in missões)
        {
            item.GetComponent<Image>().enabled = false;
        }
    }

    void Update ()
    {
		
	}
}
