using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    [SerializeField] private AudioClip[] _clips;

    /// <summary>
    /// Реализация звука
    /// </summary>
    /// <param name="var"></param>
    public void SoundPlay(int var)
    {
        _sound.clip = _clips[var];
        _sound.Play();
    }
}
