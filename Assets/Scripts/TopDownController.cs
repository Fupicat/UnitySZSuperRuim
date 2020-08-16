using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour {

    public float PVel;                                                                                  //Velocidade do jogador top-down

    Rigidbody2D rb;                                                                                     //RigidBody2D do jogador top-down
    private Vector2 moveVel;

    private void Start()
    {
        if (GetComponent<Rigidbody2D>() != null)
            rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));       //Crie um vetor bidimensional com os axis X e Y
        moveVel = move.normalized * PVel;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVel * Time.fixedDeltaTime);
    }
}
