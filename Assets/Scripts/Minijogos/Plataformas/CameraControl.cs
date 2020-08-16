using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject followTarget;
	public float moveSpeed;
	private Vector3 targetPos;

	void Update () {

		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);

	}

}
