public static class TextData
{
    private static Content[] contents = new Content[]
    {
        new Content(UIContent.Play.ToString(),"������", "Play"),
        new Content(UIContent.Info.ToString(), "����������","Info"),
        new Content(UIContent.Developers.ToString(), "������������","Developers"),
        new Content(UIContent.Story.ToString(), "�������","Story"),
        new Content(UIContent.Bestiary.ToString(), "���������","Bestiary"),
        new Content(UIContent.Armory.ToString(), "���������","Armory"),
        new Content(UIContent.Kos.ToString(), "���","Kos"),
        new Content(UIContent.Letuch.ToString(), "�����","Letuch"),
        new Content(UIContent.NewMoskow.ToString(), "������������","NewMoskow"),
        new Content(UIContent.Leshiy.ToString(), "�����","Leshiy"),
        new Content(UIContent.Ghoul.ToString(), "��������","Ghoul"),
        new Content(UIContent.GhoulS.ToString(), "�������� �","Ghoul S"),
        new Content(UIContent.Viy.ToString(), "���","Viy"),
        new Content(UIContent.LeshiyG.ToString(), "����� �","Leshiy G"),
        new Content(UIContent.HardViy.ToString(), "��� �","Viy P"),
        new Content(UIContent.Sword.ToString(), "��� \"����\"","Sword \"Klad\""),
        new Content(UIContent.Blaster.ToString(), "������� \"���\"","Blaster \"Pech\""),
        new Content(UIContent.Izlar.ToString(), "��������� \"�����\"","Guns \"Izlar\""),
        new Content(UIContent.Music.ToString(), "������","Music"),
        new Content(UIContent.Weapon.ToString(), "������","Weapon"),
        new Content(UIContent.Enemy.ToString(), "�����","Enemy"),
        new Content(UIContent.Interface.ToString(), "���������","Interface"),
        new Content(UIContent.Language.ToString(), "����","Language"),
        new Content(UIContent.RU.ToString(), "�������","russian"),
        new Content(UIContent.EN.ToString(), "����������","english"),
        new Content(UIContent.Begin.ToString(), "������","Begin"),
        new Content(UIContent.Requirements.ToString(), "����������","Requirements"),
        new Content(UIContent.Description.ToString(), "��������","Description"),
        new Content(UIContent.Choose.ToString(), "�������","Choose"),
        new Content(UIContent.More.ToString(), "���������","More"),


        new Content(LibraryContent.Level_1_Name.ToString(), "����������� \"����-40\"","To english"),

        new Content(LibraryContent.Authors.ToString(), "�� �������"

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
            "���� �� �������� ��������� ����������� ������ ����������, ��������� ���-6 ��� �������." +
            " ���� ����� �� ���� ������� ����� ����������� �������������� ������. ���� ���������� �" +
            "�������� ��������������� ���������� ���� ������ �� ���-6, ��� ������ ��� ������� ��� �" +
            "����������� �� ���������, � �������� �������� ����������� ����� � �������� � ���� ����" +
            "�� �������"

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