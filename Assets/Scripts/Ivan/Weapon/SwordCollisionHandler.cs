using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollisionHandler : MonoBehaviour
{
    private bool _dealsDamage;
    private int _damage;

    public void OnDamage(bool dealsDamage, int damage)
    {
        _dealsDamage = dealsDamage;
        _damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_dealsDamage == true)
        {
            if(collision.transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Impact(_damage);
                if(collision.transform.TryGetComponent<BulletReaction>(out BulletReaction bulletReaction))
                {
                    bulletReaction.Reaction(BulletType.PlayerBullet, collision.contacts[0].point);
                }
            }
        }
    }
}
