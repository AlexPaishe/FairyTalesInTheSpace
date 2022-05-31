using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundVolumeSystem : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup[] _mixer;
    [SerializeField] private Slider[] _sliders;
    [SerializeField] private string[] _nameSliders;
    [SerializeField] private int _minValueVolume;
    [SerializeField] private AudioSource _music;
    private int _sliderVariation;

    void Start()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].minValue = _minValueVolume;
            _sliders[i].value = PlayerPrefs.GetFloat(_nameSliders[i]);
        }
        for (int i = 0; i < _sliders.Length; i++)
        {
            _mixer[i].audioMixer.SetFloat(_nameSliders[i], PlayerPrefs.GetFloat(_nameSliders[i]));
        }
        _music.Play();
    }

    /// <summary>
    /// Реализация изменения громкости
    /// </summary>
    /// <param name="val"></param>
    public void SlidersVolume(float val)
    {
        PlayerPrefs.SetFloat(_nameSliders[_sliderVariation], val);
        _mixer[_sliderVariation].audioMixer.SetFloat(_nameSliders[_sliderVariation], val);
    }

    /// <summary>
    /// Реализация выбора слайдера
    /// </summary>
    /// <param name="var"></param>
    public void SliderVariation(int var)
    {
        _sliderVariation = var;
    }

    /// <summary>
    /// Реализация записи первого звука
    /// </summary>
    public void FirstSound()
    {
        for(int i = 0; i < _nameSliders.Length; i++)
        {
            PlayerPrefs.SetFloat(_nameSliders[i], _minValueVolume/2);
        }
    }
}
