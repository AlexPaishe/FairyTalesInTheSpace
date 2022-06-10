using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBombBlaster : MonoBehaviour
{
    [SerializeField] GameObject _bombPrefab;
    
    private GameObject _bomb;


    public void Shoot()
    {
        GameObject bomb = Instantiate(_bombPrefab, transform.position, Quaternion.identity);
        Debug.Log(transform.position);
    }
}
