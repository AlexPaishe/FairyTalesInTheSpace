public struct Content
{
    public string Title { get; }

    private string _ruContent;
    private string _enContent;

    public Content(string title, string ruContent, string enContent)
    {
        Title = title;
        _ruContent = ruContent;
        _enContent = enContent;
    }

    public string GetContent(Language language)
    {
        switch (language)
        {
            case Language.RU: return _ruContent;
            case Language.EN: return _enContent;
            default: return _ruContent;
        }
    }
}

