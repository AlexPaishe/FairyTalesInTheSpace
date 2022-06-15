using UnityEngine;

public class LibraryTranslatedText : TranslatedText
{
    [SerializeField] private LibraryContent _content;

    public override string Title => _content.ToString();
}
