using System;
using UnityEngine;

public class Translator : MonoBehaviour
{
    public event Action<Language> OnSetLanguageEvent;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey(GlobalSystemVar.currentLanguage))
        {
            Debug.Log("Нет ключа с параметром currentLanguage");
            PlayerPrefs.SetString(GlobalSystemVar.currentLanguage, GlobalSystemVar.RU);
        }

        SetLanguage(ConvertLanguage(PlayerPrefs.GetString(GlobalSystemVar.currentLanguage)));
    }

    public void SetLanguage(Language language)
    {
        this.OnSetLanguageEvent?.Invoke(language);
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
