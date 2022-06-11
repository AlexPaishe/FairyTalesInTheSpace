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
        DashVariation();
        _dash.Play();
    }

    public void DashOff()
    {
        var emission = _dash.emission;
        emission.rateOverDistance = 0;
    }

    private void DashVariation()
    {
        string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
        switch(weapon)
        {
            case GlobalSystemVar.sword: _sound[0].SoundPlay(1);  break;
            case GlobalSystemVar.izlar:
                DashOnSword();
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
        var emission = _dash.emission;
        emission.rateOverDistance = _maxRateDistance;
    }
}
