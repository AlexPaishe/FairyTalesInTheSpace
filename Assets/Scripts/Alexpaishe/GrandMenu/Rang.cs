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
    [SerializeField] private InfoSearch _info;
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
        int record = PlayerPrefs.GetInt($"Record{SceneManager.GetActiveScene().buildIndex}");
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
                    PlayerPrefs.SetInt($"Record{SceneManager.GetActiveScene().buildIndex}", _timer);
                    PlayerPrefs.SetInt($"Rang{SceneManager.GetActiveScene().buildIndex}", i);
                }
            }
        }
        _info.Init();
    }
}
