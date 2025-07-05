using Godot;
using System.Collections.Generic;

public partial class LocalizationManager : Node
{
    public static Dictionary<string, string> Translations = new();

    [Export]
    public string Language = "en";

    public override void _Ready()
    {
        LoadLanguage(Language);
    }

    public void LoadLanguage(string lang)
    {
        string path = $"res://localization/{lang}.json";
        Translations = JSONLoader.LoadJsonFile<Dictionary<string, string>>(path);
        GD.Print($"Loaded language: {lang}");
    }

    public static string Get(string key)
    {
        if (Translations.ContainsKey(key))
            return Translations[key];
        GD.Print($"[Localization Missing Key] {key}");
        return key;
    }
}
