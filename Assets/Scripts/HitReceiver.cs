using Mirror;
using UnityEngine;

public abstract class HitReceiver : NetworkBehaviour
{
    public abstract void TakeHit(Vector3 direction, int damage);
}


