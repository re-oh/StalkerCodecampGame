using System;
using Mirror;
using UnityEngine;

public class PlayerCamera : NetworkBehaviour
{
    [SyncVar]
    private float yRotatation;
    
    [SerializeField] private Camera myCamera;
    [SerializeField] private float xSensivity;
    [SerializeField] private float ySensivity;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    private void Awake()
    {
        myCamera.enabled = false;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        myCamera.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            Vector2 mouseInput = InputManager.InputActions.Player.MouseCamera.ReadValue<Vector2>();

            transform.Rotate(0f, mouseInput.x * xSensivity, 0f);

            float oldXRotation = myCamera.transform.localRotation.eulerAngles.x;
            //obejście tego, że euler zwraca 0 - 360
            if (oldXRotation > 180f)
                oldXRotation -= 360f;
            else
                oldXRotation -= 0f;
            //To samo co if powyżej
            //oldXRotation -= oldXRotation > 180f ? 360f : 0f;
            yRotatation = Mathf.Clamp(oldXRotation - mouseInput.y * ySensivity, minX, maxX);
        }

        myCamera.transform.localRotation = Quaternion.Euler(yRotatation, 0f, 0f);
    }
}
