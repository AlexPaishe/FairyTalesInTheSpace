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
            if(collision.transform.TryGetComponent<IHaveHealth>(out IHaveHealth health))
            {
                health.Impact(_damage);
            }
        }
    }
}
