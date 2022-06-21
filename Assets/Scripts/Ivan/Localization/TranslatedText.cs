using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class TranslatedText : MonoBehaviour
{
    public virtual string Title { get; private set; }

    private TMP_Text _textTMPro;
    private Text _text;

    private void Awake()
    {
        TryGetComponent<TMP_Text>(out _textTMPro);
        TryGetComponent<Text>(out _text);
    }

    public void FillText(Language language)
    {
        if (_textTMPro != null)
        {
            _textTMPro.text = TextData.GetText(language, Title);
        }

        if(_text != null)
        {
            _text.text = TextData.GetText(language, Title);
        }
    }

    private void OnEnable()
    {
        //FillText(ConvertLanguage(PlayerPrefs.GetString(GlobalSystemVar.currentLanguage)));
    }

    private Language ConvertLanguage(string language)
    {
        switch (language)
        {
            case GlobalSystemVar.RU: return Language.RU;
            case GlobalSystemVar.EN: return Language.EN;
            default: return Language.RU;
        }
    }
}
