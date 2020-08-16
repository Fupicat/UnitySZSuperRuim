using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddCreds : MonoBehaviour {

	public int CredsAAdicionar;

	public void AddCredsNormal() {

		CredsSystem.credsTotal += CredsAAdicionar;

	}

	public void AddCredsDjangia() {

		if (Door.podePegar == true) {

			Door.podePegar = false;
			CredsSystem.credsTotal += CredsAAdicionar;

		}

	}

}
