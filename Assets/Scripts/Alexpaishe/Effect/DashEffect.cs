using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dash;
    [SerializeField] private float _maxRateDistance;

    public void DashOn()
    {
        var emission = _dash.emission;
        emission.rateOverDistance = _maxRateDistance;
    }

    public void DashOff()
    {
        var emission = _dash.emission;
        emission.rateOverDistance = 0;
    }
}
