using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private SoundSystem _sound;

    private void Awake()
    {
        _sound = FindObjectOfType<SoundSystem>();
    }

    /// <summary>
    /// Реализация звуков клика
    /// </summary>
    public void Click()
    {
        _sound.Click();
    }
}
