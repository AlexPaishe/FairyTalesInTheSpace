using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoSearch : MonoBehaviour
{
    [SerializeField] private Text[] _recordText;
    [SerializeField] private Image[] _rangImage;
    [SerializeField] private Sprite[] _rangSprite;
    [SerializeField] private SoundVolumeSystem _sound;
    [SerializeField] private GameObject[] _level;
    [SerializeField] private Image[] _levelIcon;
    [SerializeField] private Text _levelText;
    [SerializeField] private string[] _infoLevel;
    [SerializeField] private Text[] _levelTitle;
    [SerializeField] private string[] _levelName;
    private int[] _rang;
    private int[] _record;
    private int _nowLevel = 0;
    private void Awake()
    {
        //PlayerPrefs.SetInt("First", 0);
        Time.timeScale = 1;
        _rang = new int[_level.Length];
        _record = new int[_level.Length];
        int first = PlayerPrefs.GetInt("First");
        if(first == 0)
        {
            PlayerPrefs.SetInt("First", 1);
            PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.sword);
            string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
            PlayerPrefs.SetInt($"Level", 0);
            for (int i = 0; i < _level.Length; i++)
            {
                PlayerPrefs.SetInt($"Rang{GlobalSystemVar.sword}{i + 1}", _rangSprite.Length - 1);
                PlayerPrefs.SetInt($"Rang{GlobalSystemVar.izlar}{i + 1}", _rangSprite.Length - 1);
                _rang[i] = PlayerPrefs.GetInt($"Rang{weapon}{i + 1}");
                PlayerPrefs.SetInt($"Record{GlobalSystemVar.sword}{i + 1}", -1);
                PlayerPrefs.SetInt($"Record{GlobalSystemVar.izlar}{i + 1}", -1);
                _record[i] = PlayerPrefs.GetInt($"Record{weapon}{i + 1}");
                _sound.FirstSound();
                Init();
            }
        }
        else
        {
            Init();
        }
    }

    /// <summary>
    /// Реализация изменения рекордов и ранга уровня
    /// </summary>
    /// <param name="var"></param>
    public void LevelSearchInfo(int var)
    {
        _nowLevel = var;
        Base.Level = _nowLevel;
        _levelText.text = _infoLevel[var];
        for(int i = 0; i < _levelTitle.Length; i++)
        {
            _levelTitle[i].text = _levelName[var];
        }
        for(int i = 0; i < _recordText.Length; i++)
        {
            if(_record[var] > -1)
            {
                _recordText[i].text = _record[var].ToString();
                _rangImage[i].sprite = _rangSprite[_rang[var]];
            }
            else
            {
                _recordText[i].text = "00:00";
                _rangImage[i].sprite = _rangSprite[5];
            }
        }
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
        int level = PlayerPrefs.GetInt($"Level");
        for (int i = 0; i < _level.Length; i++)
        {
            _rang[i] = PlayerPrefs.GetInt($"Rang{weapon}{i + 1}");
            _record[i] = PlayerPrefs.GetInt($"Record{weapon}{i + 1}");
            if (_record[i] > -1)
            {
                _levelIcon[i].sprite = _rangSprite[_rang[i]];
            }
            else
            {
                _levelIcon[i].sprite = _rangSprite[5];
            }
            if(i > level)
            {
                _level[i].SetActive(false);
            }
            else

            {
                _level[i].SetActive(true);
            }
        }
    }

    public void NowLevelRang()
    {
        LevelSearchInfo(_nowLevel);
    }
}
