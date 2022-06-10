using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rang : MonoBehaviour
{
    [SerializeField] private Text[] _recordText;
    [SerializeField] private int[] _timeRang;
    [SerializeField] private Sprite[] _rangSprite;
    [SerializeField] private Image[] _rangImage;
    private int _timer;
    public int Timer
    {
        get
        {
            return _timer;
        }

        set
        {
            _timer = value;
            TimerSearch();
        }
    }

    /// <summary>
    /// Реализация ранга и прошедшего времени
    /// </summary>
    private void TimerSearch()
    {
        string weapon = PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);
        int level = PlayerPrefs.GetInt($"Level");
        int record = PlayerPrefs.GetInt($"Record{weapon}{SceneManager.GetActiveScene().buildIndex}");
        for (int i = 0; i < _recordText.Length; i++)
        {
            _recordText[i].text = _timer.ToString();
        }
        for(int i = 0; i < _timeRang.Length; i++)
        {
            if(_timer >= _timeRang[i])
            {
                for (int j = 0; j < _rangImage.Length; j++)
                {
                    _rangImage[j].sprite = _rangSprite[i];
                }
                if (record < _timer)
                {
                    if(SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        PlayerPrefs.SetInt($"Record{GlobalSystemVar.sword}{SceneManager.GetActiveScene().buildIndex}", _timer);
                        PlayerPrefs.SetInt($"Rang{GlobalSystemVar.sword}{SceneManager.GetActiveScene().buildIndex}", i);
                        PlayerPrefs.SetInt($"Record{GlobalSystemVar.izlar}{SceneManager.GetActiveScene().buildIndex}", _timer);
                        PlayerPrefs.SetInt($"Rang{GlobalSystemVar.izlar}{SceneManager.GetActiveScene().buildIndex}", i);
                        PlayerPrefs.SetInt($"Record{GlobalSystemVar.blaster}{SceneManager.GetActiveScene().buildIndex}", _timer);
                        PlayerPrefs.SetInt($"Rang{GlobalSystemVar.blaster}{SceneManager.GetActiveScene().buildIndex}", i);
                    }
                    else
                    {
                        PlayerPrefs.SetInt($"Record{weapon}{SceneManager.GetActiveScene().buildIndex}", _timer);
                        PlayerPrefs.SetInt($"Rang{weapon}{SceneManager.GetActiveScene().buildIndex}", i);
                    }
                }
                break;
            }
        }
        if(SceneManager.GetActiveScene().buildIndex > level)
        {
            PlayerPrefs.SetInt($"Level", SceneManager.GetActiveScene().buildIndex);
        }
    }
}
