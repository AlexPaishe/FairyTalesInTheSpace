using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] _pauseSprite;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private ChangeCanvas _canvasSystem;
    private Image _pauseIcon;
    private bool _pause = false;
    public bool Pause
    {
        get
        {
            return _pause;
        }

        set
        {
            _pause = value;
            IsPause();
        }
    }

    private void Awake()
    {
        _pauseIcon = _pauseButton.GetComponent<Image>();
        Pause = false;
    }

    /// <summary>
    /// ���������� ���� �����
    /// </summary>
    private void IsPause()
    {
        if(_pause == false)
        {
            Time.timeScale = 1;
            _pauseIcon.sprite = _pauseSprite[0];
            _canvasSystem.enabled = false;
        }
        else
        {
            Time.timeScale = 0;
            _pauseIcon.sprite = _pauseSprite[1];
            _canvasSystem.enabled = true;
        }
    }

    /// <summary>
    /// ���������� ������ �����
    /// </summary>
    public void PauseOnAndOff()
    {
        Pause = !Pause;
    }

    /// <summary>
    /// ���������� �������� ������ �����
    /// </summary>
    public void Lose()
    {
        _pauseButton.SetActive(false);
    }
}
