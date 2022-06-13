using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBombBlaster : MonoBehaviour
{
    [SerializeField] GameObject _bombPrefab;
    [SerializeField] bool _isTutorial;

    private GameObject _bomb;

    public void Shoot()
    {
        GameObject bomb = Instantiate(_bombPrefab, transform.position, Quaternion.identity);

        if (_isTutorial == true)
        {
            bomb.GetComponent<BombBlaster>().IsTutorial = _isTutorial;
        } 
    }
}
