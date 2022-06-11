using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeaponMenu : MonoBehaviour
{
    [SerializeField] private Image[] _weaponIcon;
    [SerializeField] private Sprite[] _weaponSprite;
    [SerializeField] private Text[] _weaponTitle;
    [SerializeField] private string[] _weaponText;
    [SerializeField] private ModelPicture _model;
    [SerializeField] private int[] _weaponModel;
    private int _currentWeapon;
    private int _weaponMaxVariation;
    public int CurrentWeapon
    {
        get
        {
            return _currentWeapon;
        }

        set
        {
            _currentWeapon = value;
            ChangePicture();
        }
    }

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// ���������� ��������� ������ �����
    /// </summary>
    public void NextWeapon()
    {
        CurrentWeapon++;
    }

    /// <summary>
    /// ���������� ��������� ������ ������
    /// </summary>
    public void PastWeapon()
    {
        CurrentWeapon--;
    }

    /// <summary>
    /// ���������� ��������� ��������� ����
    /// </summary>
    private void NewWeapon()
    {
        for (int i = 0; i < _weaponIcon.Length; i++)
        {
            _weaponIcon[i].sprite = _weaponSprite[_currentWeapon];
        }

        for(int i = 0; i < _weaponTitle.Length; i++)
        {
            _weaponTitle[i].text = _weaponText[_currentWeapon];
        }
    }

    /// <summary>
    /// ���������� ������ ������
    /// </summary>
    public void ChangeWepon()
    {
        NewWeapon();
        switch(CurrentWeapon)
        {
            case 0: PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.sword); break;
            case 1: PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.izlar); break;
            case 2: PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.blaster); break;
        }
    }

    /// <summary>
    /// ���������� �������� �������� ��� ������ ������
    /// </summary>
    private void ChangePicture()
    {
        if (_currentWeapon == _weaponMaxVariation)
        {
            _currentWeapon = 0;
        }
        else if (_currentWeapon < 0)
        {
            _currentWeapon = _weaponMaxVariation;
        }

        _model.NewModel(_weaponModel[_currentWeapon]);
        _weaponTitle[0].text = _weaponText[_currentWeapon];
    }

    public void Init()
    {
        string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
        switch (weapon)
        {
            case GlobalSystemVar.sword: CurrentWeapon = 0; break;
            case GlobalSystemVar.izlar: CurrentWeapon = 1; break;
            case GlobalSystemVar.blaster: CurrentWeapon = 2; break;
        }

        _weaponMaxVariation = _weaponSprite.Length;

        ChangeWepon();
    }
}
