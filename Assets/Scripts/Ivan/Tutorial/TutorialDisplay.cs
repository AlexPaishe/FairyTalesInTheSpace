using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDisplay : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _interval;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _continueButton;
    [SerializeField] private GameObject _gameplayCanvas;
    //[SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private MenuSound _menuSound;

    private TutorialData _data;
    private WaitForSecondsRealtime _wait;

    private void Awake()
    {
        _data = new TutorialData();
        _wait = new WaitForSecondsRealtime(_interval);
    }

    public void OnDisplay(int step)
    {
        Time.timeScale = 0;
        _gameplayCanvas.SetActive(false);
        _menuSound.Click();
        gameObject.SetActive(true);

        StartCoroutine(GradualAppearanceText(_data.StepText[step]));
    }

    public void OffDisplay()
    {
        _continueButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        _gameplayCanvas.SetActive(true);
        _menuSound.Click();
        _text.text = "";
    }

    private IEnumerator GradualAppearanceText(string text)
    {
        int textLength = text.Length;

        for (int i = 0; i < textLength; i++)
        {
            _text.text += text[i];
            _audioSource.Play();
            yield return _wait;
        }

        _continueButton.gameObject.SetActive(true);
    }
}
