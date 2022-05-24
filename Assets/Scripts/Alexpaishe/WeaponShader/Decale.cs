using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decale : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private MeshRenderer _mesh;

    private void Start()
    {
        float rand = Random.Range(0f, 10f);
        _mesh.material.SetFloat("Random", rand);
    }

    void Update()
    {
        if(_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
