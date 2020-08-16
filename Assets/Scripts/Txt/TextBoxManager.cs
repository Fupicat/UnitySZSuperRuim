using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject txtBox;
	public Text txt;

	public TextAsset txtFile;
	public string[] txtLines;

	public int currentLine;
	public int endAtLine;

	public ScratControle player;
	public PlanetaControle planet;

	public bool isActive;
	public bool stopPlayer;

	private bool isTyping = false;
	private bool cancelTyping = false;
	public float typeSpeed;

    public bool outdoors = true;
    private Image Inv;
    private Image Mapa;

	void Start() {

		player = FindObjectOfType<ScratControle> ();

        if (outdoors)
        {
            Inv = GameObject.FindWithTag("Inv").GetComponent<Image>();
            Mapa = GameObject.FindWithTag("Mapa").GetComponent<Image>();
        }

		if (txtFile != null) {
			txtLines = (txtFile.text.Split('\n'));
		}

		if (endAtLine == 0) {

			endAtLine = txtLines.Length - 1;

		}

		if (isActive) {
			EnableTxtBox ();
		} else {
			DisableTxtBox ();
		}

	}

	void Update() {

		if (!isActive) {
			return;
		}

		//txt.text = txtLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Space)) {

			if (!isTyping) {

				currentLine += 1;

				if (currentLine > endAtLine) {

					DisableTxtBox ();

				} else {

					StartCoroutine (TextScroll (txtLines[currentLine]));

				}

			} else if (isTyping && !cancelTyping) {

				cancelTyping = true;

			}
		}
	}

	private IEnumerator TextScroll(string lineOfTxt) {

		int letter = 0;
		txt.text = "";
		isTyping = true;
		cancelTyping = false;

		while (isTyping && !cancelTyping && (letter < lineOfTxt.Length - 1)) {
			txt.text += lineOfTxt [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}

		txt.text = lineOfTxt;
		isTyping = false;
		cancelTyping = false;

	}

	public void EnableTxtBox() {
		if (stopPlayer) {
			player.canMove = false;
			planet.canMove = false;
		}
		txtBox.SetActive (true);
		isActive = true;
        if (outdoors)
        {
            Inv.enabled = false;
            Mapa.enabled = false;
        }

		StartCoroutine (TextScroll (txtLines[currentLine]));
	}

	public void DisableTxtBox() {
		txtBox.SetActive (false);
		player.canMove = true;
		planet.canMove = true;
		isActive = false;
        if (outdoors)
        {
            Inv.enabled = true;
            Mapa.enabled = true;
        }
    }

	public void ReloadScript(TextAsset theTxt) {
		if (theTxt != null) {
			txtLines = new string[1];
			txtLines = (theTxt.text.Split('\n'));
		}
	}

}
