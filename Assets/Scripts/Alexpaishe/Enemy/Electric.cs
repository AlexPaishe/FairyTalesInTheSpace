using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    //[SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private SkinnedMeshRenderer[] _mesh;
    [SerializeField] private float _speed;
    private float _electricEffect;
    public float ElectricEffect
    {
        get
        {
            return _electricEffect;
        }

        set
        {
            _electricEffect = value;
            ElectricE();
        }
    }
    void Start()
    {
        ElectricEffect = 0;
    }

    void Update()
    {
        if(ElectricEffect > 0)
        {
            ElectricEffect -= Time.deltaTime * _speed;
        }
    }

    private void ElectricE()
    {
        for (int i = 0; i < _mesh.Length; i++)
        {
            _mesh[i].material.SetFloat("_Electric", _electricEffect);
        }
        if (_electricEffect < 0)
        {
            _electricEffect = 0;
        }
    }
}
