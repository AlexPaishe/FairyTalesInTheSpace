using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _soundClick;
    [SerializeField] private AudioSource _winAndDeathSound;
    [SerializeField] private AudioClip[] _winAndLose;

    private void Awake()
    {
        _music.ignoreListenerPause = true;
        _soundClick.ignoreListenerPause = true;
    }

    /// <summary>
    /// Реализация звуков клика
    /// </summary>
    public void Click()
    {
        _soundClick.Play();
    }

    public void WinAndLose(int var)
    {
        _music.Stop();
        _winAndDeathSound.clip = _winAndLose[var];
        _winAndDeathSound.Play();
    }
}
