using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private int[] _min;
    [SerializeField] private int[] _max;

    /// <summary>
    /// Реализация звука
    /// </summary>
    /// <param name="var"></param>
    public void SoundPlay(int var)
    {
        _sound.clip = _clips[var];
        _sound.Play();
    }

    public void SoundStop()
    {
        _sound.Stop();
    }

    public void SoundVaroation(int var)
    {
        int rand = Random.Range(_min[var], _max[var]);
        _sound.clip = _clips[rand];
        _sound.Play();
    }
}
