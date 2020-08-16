using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CredsSystem : MonoBehaviour {

	public static int credsTotal = 0;
	Text allCreds;

	void Start () {
		
		allCreds = GetComponent<Text> ();

	}

	void Update () {

		allCreds.text = credsTotal.ToString ();

	}

}
