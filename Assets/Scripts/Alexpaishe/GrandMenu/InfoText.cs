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
    [SerializeField] private Image _searchButton;
    [SerializeField] private Sprite[] _icon;
    [Space]
    [SerializeField] private Text _name3dArtist;
    [SerializeField] private string[] _nameArtist;
    private bool _isModel = false;

    /// <summary>
    /// Реализация изменения текста и картинки под нужную вариацию
    /// </summary>
    /// <param name="variation"></param>
    public void VariationInformation(int variation)
    {
        _textInformationTitle.text = _textInfo[variation];
    }

    public void NameArtist(int variation)
    {
        _name3dArtist.text = _nameArtist[variation];
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

    public void NewTypeIcon()
    {
        if (_isModel == true)
        {
            _searchButton.sprite = _icon[0];
        }
        else
        {
            _searchButton.sprite = _icon[1];
        }
    }

    private void OnEnable()
    {
        _model.NewModel(_firstModel);
        VariationInformation(_firstModel);
        if (_name3dArtist != null)
        {
            NameArtist(_firstModel);
        }
    }
}
