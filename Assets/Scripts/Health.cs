using System;
using Mirror;
using UnityEngine;


public class Health : HitReceiver
{
    public event Action OnDied;
    
    [SerializeField] private int maxHp = 100;

    [SyncVar]
    private int hp;

    private bool dead = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        hp = maxHp;
    }

    public override void TakeHit(Vector3 direction, int damage)
    {
        hp -= Mathf.RoundToInt(damage);
        if (!dead && hp <= 0)
        {
            dead = true;
            OnDied?.Invoke();
        }
    }
}
