using System.Collections;
using UnityEngine;

public class Gunshot : Weapon
{
    [SerializeField] private WeaponEdit _weaponEdit;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;

    public override void StartShoot()
    {
        StartCoroutine(Shoot());
    }

    public override void StopShoot()
    {
        StopAllCoroutines();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            yield return new WaitForSeconds(_weaponEdit.shootDelay);
        }
    }
}
