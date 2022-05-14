using System;
using UnityEngine;

[RequireComponent(typeof(Collision))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private WeaponLoader _weaponLoader;
    [SerializeField] private Events _events;

    private bool _isFastAttak;

    private void Awake()
    {
        _events.OnJerkEvent += SetStatusFastAttak;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFastAttak == true)
        {
            if (collision.transform.TryGetComponent<Enemy> (out Enemy enemy))
            {
                enemy.Impact(_weaponLoader.CurrentWeapon.DamageFastAttack);
            }
        }
    }

    private void SetStatusFastAttak(bool status)
    {
        _isFastAttak = status;
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= SetStatusFastAttak;
    }
}
