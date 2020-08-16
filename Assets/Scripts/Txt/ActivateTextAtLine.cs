using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public TextBoxManager txtBox;

	public bool destroyWhenActivated;

    private bool talkBlock;

	void Start () {

		txtBox = FindObjectOfType<TextBoxManager> ();

	}

	void Update () {
		
	}

	public void StartSpeaking() {

        if (!talkBlock)
        {
            Debug.Log("Falando...");

            txtBox.ReloadScript(theText);
            txtBox.currentLine = startLine;
            txtBox.endAtLine = endLine;
            txtBox.EnableTxtBox();

            if (destroyWhenActivated)
            {
                talkBlock = true;
            }
        }

	}

}