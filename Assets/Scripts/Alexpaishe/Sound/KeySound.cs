using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour
{
    [SerializeField] private AudioSource _key;

    /// <summary>
    /// ���������� ����� �����
    /// </summary>
    public void SoundKey()
    {
        _key.Play();
    }
}
