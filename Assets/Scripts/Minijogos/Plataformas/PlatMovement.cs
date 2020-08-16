using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMovement : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	bool jumpRequest;

	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (jumpRequest == true) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			jumpRequest = false;
		}

	}

	void Update () {

		if (grounded)
			doubleJumped = false;

		if ((Input.GetButtonDown("Jump")) && grounded) {

			jumpRequest = true;

		}

		if ((Input.GetButtonDown("Jump")) && !doubleJumped && !grounded) {

			jumpRequest = true;
			doubleJumped = true;

		}

		moveVelocity = 0f;

		if (Input.GetKey(KeyCode.D)) {

			moveVelocity = moveSpeed;

		}

		if (Input.GetKey(KeyCode.A)) {

			moveVelocity = -moveSpeed;

		}

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (0.4278263f, 0.4278263f, 0.4278263f);
		} else if (GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-0.4278263f, 0.4278263f, 0.4278263f);
		}

	}

}
