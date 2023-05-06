using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Barrel : HitReceiver
{
    [SerializeField] private float radius;
    private bool exploded = false;
    public override void TakeHit(Vector3 direction, int damage)
    {
        StartCoroutine(ExplodeAfterTime());
    }

    private IEnumerator ExplodeAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Explode();
    }

    [Server]
    private void Explode()
    {
        if(exploded)
            return;
        exploded = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<Collider>().gameObject.TryGetComponent(out HitReceiver hitReceiver))
            {
                hitReceiver.TakeHit(Vector3.zero, 200);
            }
        }
        NetworkServer.Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
