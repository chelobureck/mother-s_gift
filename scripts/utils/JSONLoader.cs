using Godot;
using System.IO;
using System.Text.Json;

public partial class JSONLoader : Node
{
    public static T LoadJsonFile<T>(string path)
    {
        var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        string text = file.GetAsText();
        file.Close();
        return JsonSerializer.Deserialize<T>(text);
    }
}