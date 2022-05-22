using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _soundClick;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource[] _character;
    [Header("Character")]
    [SerializeField] private AudioClip[] _characterClips;
    [SerializeField] private AudioClip[] _dash;
    [Header("Enemy")]
    [SerializeField] private AudioClip[] _leshyClip;

    private int _dashLength;

    private void Awake()
    {
        _music.ignoreListenerPause = true;
        _soundClick.ignoreListenerPause = true;
        _dashLength = _dash.Length;
    }

    #region ����
    /// <summary>
    /// ���������� ����� �����
    /// </summary>
    public void Click()
    {
        _soundClick.Play();
    }
    #endregion

    #region ���

    /// <summary>
    /// ���������� ����� ����
    /// </summary>
    public void Step()
    {
        _character[0].Play();
    }

    /// <summary>
    /// ���������� ������� ����� � �����
    /// </summary>
    /// <param name="var"></param>
    public void UpCharacter(int var)
    {
        _character[1].clip = _characterClips[var];
        _character[1].Play();
    }

    /// <summary>
    /// ���������� ������ ����
    /// </summary>
    public void Dash()
    {
        int rand = Random.Range(0, _dashLength);
        _character[1].clip = _dash[rand];
        _character[1].Play();
    }

    #endregion
}
