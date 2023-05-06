using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        
        Vector2 moveVec = InputManager.InputActions.Player.Move.ReadValue<Vector2>();
        moveVec *= speed;
        Vector3 vel = new Vector3(0f, rb.velocity.y, 0f);
        vel += transform.forward * moveVec.y;
        vel += transform.right * moveVec.x;
        rb.velocity = vel;
    }
}

