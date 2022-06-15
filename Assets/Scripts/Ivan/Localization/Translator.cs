using System;
using UnityEngine;
using UnityEngine.UI;

public class Translator : MonoBehaviour
{
    [SerializeField] private Button _enButton;
    [SerializeField] private Button _ruButton;

    private TranslatedText[] translatedTexts;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey(GlobalSystemVar.currentLanguage))
        {
            PlayerPrefs.SetString(GlobalSystemVar.currentLanguage, GlobalSystemVar.RU);
        }
    }

    private void Start()
    {
        translatedTexts = GetComponentsInChildren<TranslatedText>(true);

        SetLanguage(ConvertLanguage(PlayerPrefs.GetString(GlobalSystemVar.currentLanguage)));
    }

    private void OnEnable()
    {
        _enButton.onClick.AddListener(SetEnglish);
        _ruButton.onClick.AddListener(SetRussian);
    }

    private void OnDisable()
    {
        _enButton.onClick.RemoveListener(SetEnglish);
        _ruButton.onClick.RemoveListener(SetRussian);
    }

    public void SetLanguage(Language language)
    {
        foreach (var text in translatedTexts)
        {
            text.FillText(language);
        }

        PlayerPrefs.SetString(GlobalSystemVar.currentLanguage, language.ToString());
    }

    private void SetEnglish()
    {
        foreach (var text in translatedTexts)
        {
            text.FillText(Language.EN);
        }

        PlayerPrefs.SetString(GlobalSystemVar.currentLanguage, GlobalSystemVar.EN);
    }

    private void SetRussian()
    {
        foreach (var text in translatedTexts)
        {
            text.FillText(Language.RU);
        }

        PlayerPrefs.SetString(GlobalSystemVar.currentLanguage, GlobalSystemVar.RU);
    }

    private Language ConvertLanguage (string language)
    {
        switch (language)
        {
            case GlobalSystemVar.RU: return Language.RU;
            case GlobalSystemVar.EN: return Language.EN;
            default: return Language.RU;
        }
    }
}

public enum Language
{
    RU, EN
}
