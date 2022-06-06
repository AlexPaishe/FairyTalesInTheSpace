using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    [SerializeField] private string[] _textInfo;
    [SerializeField] private Text _textInformationTitle;
    [SerializeField] private CanvasGroup[] _typeInfo;
    [SerializeField] private int _firstModel;
    [SerializeField] private ModelPicture _model;
    private bool _isModel = false;

    /// <summary>
    /// Реализация изменения текста и картинки под нужную вариацию
    /// </summary>
    /// <param name="variation"></param>
    public void VariationInformation(int variation)
    {
        for(int i = 0; i < _textInfo.Length; i++)
        {
            _textInformationTitle.text = _textInfo[variation];
        }
    }

    public void TypeInformation()
    {
        int models = 0;
        if(_isModel == false)
        {
            models = 1;
        }
        _isModel = !_isModel;
        for(int i = 0; i < _typeInfo.Length; i++)
        {
            if(i == models)
            {
                _typeInfo[i].blocksRaycasts = true;
                _typeInfo[i].interactable = true;
                _typeInfo[i].alpha = 1;
            }
            else
            {
                _typeInfo[i].blocksRaycasts = false;
                _typeInfo[i].interactable = false;
                _typeInfo[i].alpha = 0;
            }
        }
    }

    private void OnEnable()
    {
        _model.NewModel(_firstModel);
        VariationInformation(_firstModel);
    }
}
