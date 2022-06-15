public static class TextData
{
    private static Content[] contents = new Content[]
    {
        new Content(UIContent.Play.ToString(),"Играть", "Play"),
        new Content(UIContent.Info.ToString(), "Информация","Info"),
        new Content(UIContent.Developers.ToString(), "Разработчики","Developers"),
        new Content(UIContent.Story.ToString(), "История","Story"),
        new Content(UIContent.Bestiary.ToString(), "Бестиарий","Bestiary"),
        new Content(UIContent.Armory.ToString(), "Оружейная","Armory"),
        new Content(UIContent.Kos.ToString(), "Кос","Kos"),
        new Content(UIContent.Letuch.ToString(), "Летуч","Letuch"),
        new Content(UIContent.NewMoskow.ToString(), "Новомосковье","NewMoskow"),
        new Content(UIContent.Leshiy.ToString(), "Леший","Leshiy"),
        new Content(UIContent.Ghoul.ToString(), "Вурдалак","Ghoul"),
        new Content(UIContent.GhoulS.ToString(), "Вурдалак С","Ghoul S"),
        new Content(UIContent.Viy.ToString(), "Вий","Viy"),
        new Content(UIContent.LeshiyG.ToString(), "Леший Г","Leshiy G"),
        new Content(UIContent.HardViy.ToString(), "Вий П","Viy P"),
        new Content(UIContent.Sword.ToString(), "Меч \"Клад\"","Sword \"Klad\""),
        new Content(UIContent.Blaster.ToString(), "Бластер \"Печ\"","Blaster \"Pech\""),
        new Content(UIContent.Izlar.ToString(), "Пистолеты \"Излар\"","Guns \"Izlar\""),
        new Content(UIContent.Music.ToString(), "Музыка","Music"),
        new Content(UIContent.Weapon.ToString(), "Оружие","Weapon"),
        new Content(UIContent.Enemy.ToString(), "Враги","Enemy"),
        new Content(UIContent.Interface.ToString(), "Интерфейс","Interface"),
        new Content(UIContent.Language.ToString(), "Язык","Language"),
        new Content(UIContent.RU.ToString(), "русский","russian"),
        new Content(UIContent.EN.ToString(), "английский","english"),
        new Content(UIContent.Begin.ToString(), "Начать","Begin"),
        new Content(UIContent.Requirements.ToString(), "Требования","Requirements"),
        new Content(UIContent.Description.ToString(), "Описание","Description"),
        new Content(UIContent.Choose.ToString(), "Выбрать","Choose"),
        new Content(UIContent.More.ToString(), "Подробнее","More"),


        new Content(LibraryContent.Level_1_Name.ToString(), "Лаборатория \"Скол-40\"","To english"),

        new Content(LibraryContent.Authors.ToString(), "На русском"

            ,"Zharov Vitaliy - Team Lead, Game Design, Level Design, Creative Director\n\n" +
            "Artemii Korshunov - Game Design, Level Design\n\n" +
            "Ivan Vakulyn - Developer, Animations\n\n" +
            "Alexander Pashkovskiy - Developer, VFX, UI Design\n\n" +
            "Sofia Anashkina - Concept Artist, 2d Artist\n\n" +
            "Roman Andreiev - 3d Artist\n\n" +
            "Shamil Emeiev - 3d Artist\n\n" +
            "Eugenie Osipov - Sound Design\n\n" +
            "Daniil Masiuk - Mentor"),

        new Content(LibraryContent.level_1_Description.ToString(), 
            "Один из частично уцелевших космических портов Новосковья, выбранный Кос-6 для посадки." +
            " Даже здесь на краю станции видны последствия разрастающейся заразы. Тела охранников о" +
            "кутанные растительностью направляют свое оружие на Кос-6, как только его тяжелый шаг о" +
            "брушивается на платформу, а растения обретают гуманойдную форму и тянуться к нему свои" +
            "ми когтями"

            ,"To English")
    };

    public static string GetText(Language language, string title)
    {
        string text = "";

        foreach (Content content in contents)
        {
            if (title == content.Title)
            {
                text = content.GetContent(language);
            }
        }

        return text;
    }
} 

public enum UIContent
{
    Play, Info, Developers, Story, Bestiary, Armory, Kos, Letuch, NewMoskow, Leshiy,
    Ghoul, GhoulS, Viy, LeshiyG, HardViy, Sword, Blaster, Izlar, Music, Weapon, Enemy,
    Interface, Language, RU, EN, Begin, Requirements, Description, Choose, More
}

public enum LibraryContent
{
    Level_1_Name, level_1_Description,
    Authors
}

public enum TutorialContent
{

}