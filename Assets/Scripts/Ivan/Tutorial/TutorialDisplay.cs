using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialDisplay : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _letterInterval;
    [SerializeField] private int _soundInterval;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _infoButton;
    [SerializeField] private GameObject _gameplayCanvas;
    [SerializeField] private GameObject _statButtonPanel;
    [SerializeField] private MenuSound _menuSound;
    [SerializeField] private WeaponLoader _weaponLoader;
    [SerializeField] private PlayerMovement _playerMovement;

    private TutorialData _data;
    private WaitForSecondsRealtime _waitLetter;
    private Coroutine _gradualAppearanceText;
    private int _step;

    private void Awake()
    {
        _data = new TutorialData();
        _waitLetter = new WaitForSecondsRealtime(_letterInterval);
    }

    private void Start()
    {
        _infoButton.gameObject.SetActive(true);
        _continueButton.gameObject.SetActive(false);

        OnDisplayToTrigger(0);
    }

    public void OnDisplayToTrigger(int step)
    {
        _step = step;
        Time.timeScale = 0;

        _statButtonPanel.SetActive(false);
        _gameplayCanvas.SetActive(false);

        gameObject.SetActive(true);

        _text.text = "";

        _gradualAppearanceText = StartCoroutine(GradualAppearanceText(_data.StepText[step]));
        _menuSound.Click();
    }

    public void ShowAllText()
    {
        if (_gradualAppearanceText != null)
        {
            StopCoroutine(_gradualAppearanceText);
        }
        _text.text = _data.StepText[_step];
        _continueButton.gameObject.SetActive(true);
    }

    public void OnLastDisplay()
    {
        Time.timeScale = 0;

        _statButtonPanel.SetActive(false);
        _gameplayCanvas.SetActive(false);

        gameObject.SetActive(true);
        _continueButton.gameObject.SetActive(true);
        _menuSound.Click();
    }

    public void OffDisplay()
    {
        Time.timeScale = 1;

        gameObject.SetActive(false);
        _continueButton.gameObject.SetActive(false);

        _statButtonPanel.SetActive(true);
        _gameplayCanvas.SetActive(true);
        _menuSound.Click();

        _weaponLoader.CurrentWeapon.StopShoot();
        _playerMovement.RestMovement();
    }

    private IEnumerator GradualAppearanceText(string text)
    {
        int textLength = text.Length;

        for (int i = 0; i < textLength; i++)
        {
            _text.text += text[i];

            if(i%_soundInterval == 0)
            {
                _audioSource.Play();
            }

            yield return _waitLetter;
        }

        _continueButton.gameObject.SetActive(true);
    }
}
