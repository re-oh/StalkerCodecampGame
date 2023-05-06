using System;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class InputManager : MonoBehaviour
{
    public static InputActions InputActions;
    
    private void Awake()
    {
        InputActions = new InputActions();
        InputActions.Enable();
    }
}
