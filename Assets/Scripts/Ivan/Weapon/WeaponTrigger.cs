using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    [SerializeField] private WeaponLoader _weaponLoader;
    [SerializeField] private int _index;
    [SerializeField] private GameObject[] _weaponVisual;

    private void Start()
    {
        ShowWeapon(_index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            ShowWeapon(_weaponLoader.CurrentWeapon.Index);
            _weaponLoader.ChangeWeapon(WeaponName(_index));
        }
    }

    private void ShowWeapon(int index)
    {
        if (index == 3)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < _weaponVisual.Length; i++)
            {
                if (i == index)
                {
                    _weaponVisual[i].gameObject.SetActive(true);
                }
                else
                {
                    _weaponVisual[i].gameObject.SetActive(false);
                }
            }
        } 
    }

    private string WeaponName(int index)
    {
        switch (index)
        {
            case 0: 
                return GlobalSystemVar.izlar;
            case 1: 
                return GlobalSystemVar.sword;
            case 2:
                return GlobalSystemVar.blaster;
            default:
                return GlobalSystemVar.unarmed;
        }
    }
}
