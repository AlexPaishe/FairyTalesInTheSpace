using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : Weapon
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private LineRenderer _lineRenderer;

    public override void StartShoot()
    {
        _lineRenderer.gameObject.SetActive(true);
    }

    public override void StopShoot()
    {
        _lineRenderer.gameObject.SetActive(false);
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }

    private void Update()
    {
        if(_lineRenderer.gameObject.activeSelf == true)
        {
            RaycastHit hit;

            _lineRenderer.SetPosition(0, _shootPoint.position);

            if (Physics.Raycast(_shootPoint.position, _shootPoint.forward, out hit))
            {
                _lineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}
