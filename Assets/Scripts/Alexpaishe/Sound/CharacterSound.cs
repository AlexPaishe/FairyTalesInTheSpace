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
    /// ���������� ���
    /// </summary>
    public void Step()
    {
        _sound.Step();
    }

    /// <summary>
    /// ���������� ������ ��������
    /// </summary>
    public void ShootSoundIzlar()
    {
        _sound.UpCharacter(0);
    }

    /// <summary>
    /// ���������� ����� �����
    /// </summary>
    public void DashSound()
    {
        _sound.Dash();
    }
}
