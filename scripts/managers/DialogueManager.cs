using Godot;
using System.Collections.Generic;

public partial class DialogueManager : Node
{
    [Signal]
    public delegate void DialogueUpdatedEventHandler(string speaker, string text);

    [Signal]
    public delegate void DialogueEndedEventHandler();

    [Export]
    public string DialoguePath = "";

    private List<DialogueLine> lines = new();
    private int currentIndex = 0;
    private List<Choice> currentChoices = null;

    public override void _Ready()
    {
        if (!string.IsNullOrEmpty(DialoguePath))
        {
            LoadDialogue();
            Advance();
        }
    }

    private void LoadDialogue()
    {
        lines = JSONLoader.LoadJsonFile<List<DialogueLine>>(DialoguePath);
        GD.Print($"Loaded {lines.Count} dialogue lines from {DialoguePath}");
    }

    public void Advance(int choiceNextId = -1)
    {
        if (choiceNextId > 0)
        {
            currentIndex = lines.FindIndex(l => l.id == choiceNextId);
            GD.Print($"Advancing by choice to ID: {choiceNextId}");
        }

        if (currentIndex < 0 || currentIndex >= lines.Count)
        {
            GD.Print("Dialogue finished!");
            EmitSignal(nameof(DialogueEnded));
            return;
        }

        var line = lines[currentIndex];
        currentChoices = line.choices;
        GD.Print($"[Dialogue] {line.speaker}: {line.text}");
        EmitSignal(nameof(DialogueUpdated), line.speaker, line.text);

        if (line.choices == null || line.choices.Count == 0)
        {
            currentIndex = lines.FindIndex(l => l.id == line.next);
        }
    }

    public List<Choice> GetCurrentChoices()
    {
        return currentChoices;
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