using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desolve : MonoBehaviour
{
    [SerializeField] private Renderer[] _mesh;
    [SerializeField] private float _speedDesolve;
    private float _fade = 1.5f;
    private bool _desolve;
    private Win _win;

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

    private void Awake()
    {
        _win = FindObjectOfType<Win>();

    }

    void Update()
    {
        if(_desolve == true)
        {
            Fade -= Time.deltaTime * _speedDesolve;
        }
    }

    /// <summary>
    /// ���������� ������������
    /// </summary>
    private void FadeEnemy()
    {
        for(int i = 0; i < _mesh.Length; i++)
        {
            _mesh[i].material.SetFloat("_Fade", _fade);
        }
        if(_fade < 0)
        {
            _win.EnemyLenght--;
            Destroy(transform.parent.gameObject);
        }
    }

    /// <summary>
    /// ���������� ������
    /// </summary>
    public void DesolveEnemy()
    {
        _desolve = true;
    }
}
