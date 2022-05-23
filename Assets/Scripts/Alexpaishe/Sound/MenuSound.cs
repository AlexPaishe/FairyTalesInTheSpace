using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _soundClick;

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
}
