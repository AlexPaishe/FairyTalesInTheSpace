using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dash;
    [SerializeField] private float _maxRateDistance;
    [SerializeField] private Rigidbody _rb;

    public void DashOn()
    {
        var emission = _dash.emission;
        emission.rateOverDistance = _maxRateDistance;
    }

    private void Update()
    {
        float x = Mathf.Abs(_rb.velocity.x);
        float z = Mathf.Abs(_rb.velocity.z);
        float xz = x + z;
        Debug.Log(xz);
        if (xz < 10)
        {
            var emission = _dash.emission;
            emission.rateOverDistance = 0;
        }
    }
}
