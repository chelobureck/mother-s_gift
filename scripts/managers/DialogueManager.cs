using Godot;
using System.Collections.Generic;

public partial class DialogueManager : Node
{
    [Export] public string DialoguePath = "res://dialogue_data/chapter1/room_hero.json";
    private List<DialogueLine> lines;
    private int currentIndex = 0;

    [Signal] public delegate void DialogueUpdatedEventHandler(string speaker, string text, List<Choice> choices);

    public override void _Ready()
    {
        LoadDialogue();
        Advance();
    }

    private void LoadDialogue()
    {
        lines = JSONLoader.LoadJsonFile<List<DialogueLine>>(DialoguePath);
    }

    public void Advance(int choiceNextId = -1)
    {
        if (choiceNextId > 0)
        {
            currentIndex = lines.FindIndex(l => l.id == choiceNextId);
        }

        if (currentIndex >= lines.Count)
        {
            GD.Print("Dialogue ended.");
            return;
        }

        var line = lines[currentIndex];
        EmitSignal(nameof(DialogueUpdated), line.speaker, line.text, line.choices);
        currentIndex = lines.FindIndex(l => l.id == line.next);
    }
}

public class DialogueLine
{
    public int id { get; set; }
    public string speaker { get; set; }
    public string text { get; set; }
    public List<Choice> choices { get; set; }
    public int next { get; set; }
}

public class Choice
{
    public string text { get; set; }
    public int next { get; set; }
}