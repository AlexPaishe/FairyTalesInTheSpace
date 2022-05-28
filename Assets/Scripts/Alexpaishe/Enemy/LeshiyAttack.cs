using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeshiyAttack : MonoBehaviour
{
    [SerializeField] private LeshiyMove _leshiy;
    [SerializeField] private GameObject[] _attackZone;
    [SerializeField] private int _damage;
    private int _attack = 0;

    private void Awake()
    {
        for(int i = 0; i < _attackZone.Length; i++)
        {
            EnemyAttack attackDamage = _attackZone[i].GetComponent<EnemyAttack>();
            attackDamage.NewDamage(_damage);
        }
    }

    /// <summary>
    /// Реализация атаки
    /// </summary>
    public void Attack()
    {
        _attack++;
        if(_attack > 1)
        {
            _attack = 0;
        }

        switch(_attack)
        {
            case 0: _leshiy.Anima.SetTrigger("LeftAttack"); break;
            case 1: _leshiy.Anima.SetTrigger("RightAttack"); break;
        }
    }

    /// <summary>
    /// Реализация окончания атаки
    /// </summary>
    public void IsAttackEnd()
    {
        _leshiy.IsAttack = false;
    }

    public void AttackZoneOn(int var)
    {
        _attackZone[var].SetActive(true);
    }

    public void AttackZoneOff(int var)
    {
        _attackZone[var].SetActive(false);
    }
}
