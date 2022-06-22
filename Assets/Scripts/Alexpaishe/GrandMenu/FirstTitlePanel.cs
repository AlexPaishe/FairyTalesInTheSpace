using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstTitlePanel : MonoBehaviour
{
    [SerializeField] private Text[] _textTitle;
    [SerializeField] private string[] _textInfo;
    [SerializeField] private GameObject[] _panel;
    [SerializeField] private float _speed;
    [SerializeField] private float _soundInteval;
    [SerializeField] private AudioSource _click;
    [SerializeField] private MenuSound _menuSound;

    private WaitForSecondsRealtime _oneChar;
    private Coroutine _gradualAppearanceText;
    private bool _textIsShow = false;
    private int _step = 0;

    private void Awake()
    {
        _oneChar= new WaitForSecondsRealtime(_speed);
    }

    void Start()
    {
        _panel[_step].SetActive(true);
        _menuSound.Click();
        _gradualAppearanceText = StartCoroutine(InfoFirst(_textInfo[_step]));
    }

    public void ShowAllTextAndContinue()
    {
        if (_textIsShow == false)
        {
            if (_gradualAppearanceText != null)
            {
                StopCoroutine(_gradualAppearanceText);
            }
            _textTitle[_step].text = _textInfo[_step];

            _textIsShow = true;
        }
        else
        {
            OffDisplay();
        }
    }

    private IEnumerator InfoFirst(string text)
    {
        int textLength = text.Length;

        for (int i = 0; i < textLength; i++)
        {
            _textTitle[_step].text += text[i];

            if (i % _soundInteval == 0)
            {
                _click.Play();
            }

            yield return _oneChar;
        }

        _textIsShow = true;
    }

    private void OffDisplay()
    {
        _panel[_step].SetActive(false);
        _step++;
        if(_step < _textTitle.Length)
        {
            _panel[_step].SetActive(true);
            _gradualAppearanceText = StartCoroutine(InfoFirst(_textInfo[_step]));
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
