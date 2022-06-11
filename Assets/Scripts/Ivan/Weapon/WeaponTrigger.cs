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
            int temp = _weaponLoader.CurrentWeapon.Index;

            ShowWeapon(temp);
            _weaponLoader.ChangeWeapon(WeaponName(_index));
            _index = temp;
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
                PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.izlar);
                return GlobalSystemVar.izlar;
            case 1:
                PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.sword);
                return GlobalSystemVar.sword;
            case 2:
                PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.blaster);
                return GlobalSystemVar.blaster;
            default:
                return GlobalSystemVar.unarmed;
        }
    }
}
