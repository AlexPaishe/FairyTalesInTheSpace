using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    private SoundSystem _sound;

    private void Awake()
    {
        _sound = FindObjectOfType<SoundSystem>();
    }

    /// <summary>
    /// Реализация шаг
    /// </summary>
    public void Step()
    {
        _sound.Step();
    }

    /// <summary>
    /// Реализация звуков выстрела
    /// </summary>
    public void ShootSoundIzlar()
    {
        _sound.UpCharacter(0);
    }

    /// <summary>
    /// Реализация звука рывка
    /// </summary>
    public void DashSound()
    {
        _sound.Dash();
    }
}
