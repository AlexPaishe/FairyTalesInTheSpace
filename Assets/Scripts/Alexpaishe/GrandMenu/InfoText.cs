using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    [SerializeField] private string[] _textInfo;
    [SerializeField] private Text _textInformationTitle;
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite[] _spriteIcon;

    /// <summary>
    /// Реализация изменения текста и картинки под нужную вариацию
    /// </summary>
    /// <param name="variation"></param>
    public void VariationInformation(int variation)
    {
        for(int i = 0; i < _textInfo.Length; i++)
        {
            _icon.sprite = _spriteIcon[variation];
            _textInformationTitle.text = _textInfo[variation];
        }
    }
}
