using UnityEngine;


public class BodyPart : HitReceiver
{
    [SerializeField] private float dmgModifier = 1f;
    public override void TakeHit(Vector3 direction, int damage)
    {
        transform.GetComponentInParent<Health>().TakeHit(direction, Mathf.RoundToInt(damage * dmgModifier));
    }
}
