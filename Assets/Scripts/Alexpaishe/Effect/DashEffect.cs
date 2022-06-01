using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dash;
    [SerializeField] private float _maxRateDistance;
    [SerializeField] private Sound[] _sound;

    public void DashOn()
    {
        var emission = _dash.emission;
        emission.rateOverDistance = _maxRateDistance;
        emission.rateOverTime = _maxRateDistance * 2;
        _sound[0].SoundPlay(0);
        _sound[1].SoundVaroation(0);
        _dash.Play();
    }

    public void DashOff()
    {
        var emission = _dash.emission;
        emission.rateOverDistance = 0;
        emission.rateOverTime = 0;
    }
}
