using Godot;
using System.Collections.Generic;

public partial class DialogueBox : Control
{
    [Signal]
    public delegate void ChoiceSelectedEventHandler(int nextId);

    [Export]
    public Label SpeakerLabel;

    [Export]
    public Label TextLabel;

    [Export]
    public VBoxContainer ChoiceContainer;

    [Export]
    public PackedScene ChoiceButtonPrefab;

    public void UpdateDialogue(string speaker, string text, List<Choice> choices)
    {
        GD.Print($"Updating DialogueBox UI for speaker: {speaker}");
        SpeakerLabel.Text = LocalizationManager.Get(speaker);
        TextLabel.Text = LocalizationManager.Get(text);

        // Clear old choices
        foreach (Node child in ChoiceContainer.GetChildren())
        {
            child.QueueFree();
        }

        if (choices != null && choices.Count > 0)
        {
            GD.Print($"Generating {choices.Count} choices");
            foreach (var choice in choices)
            {
                var button = ChoiceButtonPrefab.Instantiate<Button>();
                button.Text = LocalizationManager.Get(choice.text);
                button.Pressed += () => EmitSignal(nameof(ChoiceSelected), choice.next);
                ChoiceContainer.AddChild(button);
            }
        }
    }
}
