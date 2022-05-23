using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desolve : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private float _speedDesolve;
    private float _fade = 1.5f;
    private bool _desolve;

    public float Fade
    {
        get
        {
            return _fade;
        }

        set
        {
            _fade = value;
            FadeEnemy();
        }
    }

    void Update()
    {
        if(_desolve == true)
        {
            Fade -= Time.deltaTime * _speedDesolve;
        }
    }

    /// <summary>
    /// Реализация исчезновения
    /// </summary>
    private void FadeEnemy()
    {
        for(int i = 0; i < _mesh.Length; i++)
        {
            _mesh[i].material.SetFloat("_Fade", _fade);
        }
        if(_fade < 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    /// <summary>
    /// Реализация смерти
    /// </summary>
    public void DesolveEnemy()
    {
        _desolve = true;
    }
}
