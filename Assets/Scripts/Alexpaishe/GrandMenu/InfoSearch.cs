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
    [SerializeField] private int _maxLevel;
    [SerializeField] private SoundVolumeSystem _sound;
    private int[] _rang;
    private int[] _record;
    private void Awake()
    {
        _rang = new int[_maxLevel];
        _record = new int[_maxLevel];
        int first = PlayerPrefs.GetInt("First");
        if(first == 0)
        {
            PlayerPrefs.SetInt("First", 1);
            for(int i = 0; i < _maxLevel; i++)
            {
                PlayerPrefs.SetInt($"Rang{i + 1}", _rangSprite.Length - 1);
                _rang[i] = PlayerPrefs.GetInt($"Rang{i + 1}");
                PlayerPrefs.SetInt($"Record{i + 1}", -1);
                _record[i] = PlayerPrefs.GetInt($"Record{i + 1}");
                _sound.FirstSound();
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
                _rangImage[i].sprite = _rangSprite[0];
            }
        }
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    public void Init()
    {
        for (int i = 0; i < _maxLevel; i++)
        {
            _rang[i] = PlayerPrefs.GetInt($"Rang{i + 1}");
            _record[i] = PlayerPrefs.GetInt($"Record{i + 1}");
        }
    }
}
