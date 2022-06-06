using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPicture : MonoBehaviour
{
    [SerializeField] private Transform _modelPodium;
    [SerializeField] private GameObject[] _model;
    [SerializeField] private float _speed;
    private float _rotate = 0;
    void Start()
    {
        WeaponChangeModel();
    }

    void Update()
    {
        _rotate = Time.deltaTime * _speed;
        _modelPodium.Rotate(0, _rotate, 0);
    }

    public void NewModel(int var)
    {
        for(int i = 0; i < _model.Length; i++)
        {
            if(i == var)
            {
                _model[i].SetActive(true);
            }
            else
            {
                _model[i].SetActive(false);
            }
        }
    }

    public void WeaponChangeModel()
    {
        string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
        switch (weapon)
        {
            case GlobalSystemVar.sword: NewModel(0); break;
            case GlobalSystemVar.izlar: NewModel(1); break;
        }
    }
}
