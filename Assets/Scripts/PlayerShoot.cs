using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform shootPoint;
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        InputManager.InputActions.Player.Shoot.performed += OnShootPerformed;
    }

    private void OnShootPerformed(InputAction.CallbackContext ctx)
    {
        ShootCmd();
    }

    [Command]
    private void ShootCmd()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, mask))
        {
            ShootParticleRpc(hitInfo.point);
            if (hitInfo.collider.gameObject.TryGetComponent(out HitReceiver hitReceiver))
            {
                hitReceiver.TakeHit(hitInfo.normal, 50);
            }
        }
    }

    [ClientRpc]
    private void ShootParticleRpc(Vector3 point)
    {
        //odpal odprysk
    }
}
