using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private int _damage = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            player.Impact(_damage);
            gameObject.SetActive(false);
        }
    }

    public void NewDamage(int damage)
    {
        _damage = damage;
    }
}
