using Mirror;
using UnityEngine;


public class DespawnOnDeath : NetworkBehaviour
{
    public override void OnStartServer()
    {
        base.OnStartServer();
        GetComponent<Health>().OnDied += OnDied;
    }

    private void OnDied()
    {
        NetworkServer.Destroy(gameObject);
    }
}
