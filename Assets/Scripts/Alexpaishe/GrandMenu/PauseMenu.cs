using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] _pauseSprite;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private ChangeCanvas _canvasSystem;
    [SerializeField] private WeaponLoader _weapon;
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

    private void Start()
    {
        _pauseIcon = _pauseButton.GetComponent<Image>();
        Pause = false;
    }

    /// <summary>
    /// ?????????? ???? ?????
    /// </summary>
    private void IsPause()
    {
        if(_pause == false)
        {
            Time.timeScale = 1;
            _pauseIcon.sprite = _pauseSprite[0];
            _canvasSystem.NewCanvas(12);
            AudioListener.pause = false;
        }
        else
        {
            Time.timeScale = 0;
            _pauseIcon.sprite = _pauseSprite[1];
            _canvasSystem.NewCanvas(0);
            string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
            if (weapon == "Izlar")
            {
                _weapon.CurrentWeapon.StopShoot();
            }
            AudioListener.pause = true;
        }
    }

    /// <summary>
    /// ?????????? ?????? ?????
    /// </summary>
    public void PauseOnAndOff()
    {
        Pause = !Pause;
    }

    /// <summary>
    /// ?????????? ???????? ?????? ?????
    /// </summary>
    public void Lose()
    {
        _pauseButton.SetActive(false);
    }
}
