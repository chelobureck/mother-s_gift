using Godot;
using System.Collections.Generic;

public partial class LocalizationManager : Node
{
    public static Dictionary<string, string> Translations = new();

    public static void LoadLanguage(string lang)
    {
        string path = $"res://localization/{lang}.json";
        Translations = JSONLoader.LoadJsonFile<Dictionary<string, string>>(path);
    }

    public static string Get(string key)
    {
        return Translations.ContainsKey(key) ? Translations[key] : key;
    }
}