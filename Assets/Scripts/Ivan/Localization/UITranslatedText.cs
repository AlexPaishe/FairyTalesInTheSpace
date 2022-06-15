using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITranslatedText : TranslatedText
{
    [SerializeField] private UIContent _content;

    public override string Title => _content.ToString();
}
