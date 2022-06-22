using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzlarBullet : Bullet
{
    public override void OnCollisionEnter(Collision collision)
    {
        Collider[] hits = Physics.OverlapSphere(collision.contacts[0].point, base.edit.damageRadius);

        foreach (Collider hit in hits)
        {
            if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Impact(base.edit.damage);

                if (collision.transform.TryGetComponent<BulletReaction>(out BulletReaction bulletReaction))
                {
                    bulletReaction.Reaction(base.edit.bulletType, hit.transform.position);
                }
            }
        }

        gameObject.SetActive(false);
    }
}
