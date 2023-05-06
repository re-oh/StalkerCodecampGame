using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private void Awake()
    {

    }
}

private void FixedUpdate()
{
    if (!isLocalPLayer)
    {
        return
    }
    Vector2 moveVec = InputManager.InputActions.Player.Move.ReadValue<Vector2>();
    moveVec += speed;
    vel += transform.forward * moveVec.y;
    vel += transform.right * moveVec.x;
    
}
