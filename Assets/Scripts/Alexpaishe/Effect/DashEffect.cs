using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _dash;
    [SerializeField] private float _maxRateDistance;
    [SerializeField] private Sound[] _sound;

    public void DashOn()
    {
        DashVariation();
    }

    public void DashOff()
    {
        var emission = _dash[0].emission;
        emission.rateOverDistance = 0;
        var emissionB = _dash[1].emission;
        emissionB.rateOverDistance = 0;
    }

    private void DashIzlar()
    {
        var emission = _dash[0].emission;
        emission.rateOverDistance = _maxRateDistance;
    }

    private void DashVariation()
    {
        string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
        switch(weapon)
        {
            case GlobalSystemVar.sword: _sound[0].SoundPlay(1);  break;
            case GlobalSystemVar.izlar:
                DashIzlar();
                _dash[0].Play();
                _sound[0].SoundPlay(0);
                _sound[1].SoundVaroation(0);
                StartCoroutine(DashOffCourutine(0.8f));
                break;
            //case GlobalSystemVar.blaster: CurrentWeapon = 2; break;
        }
    }

    IEnumerator DashOffCourutine(float second)
    {
        yield return new WaitForSeconds(second);
        DashOff();
    }

    public void DashOffSword(float second)
    {
        StartCoroutine(DashOffCourutine(second));
    }

    public void DashOnSword()
    {
        var emission = _dash[1].emission;
        emission.rateOverDistance = _maxRateDistance;
        _dash[1].Play();
    }
}
