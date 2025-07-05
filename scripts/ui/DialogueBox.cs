using Godot;
using System.Collections.Generic;

public partial class DialogueBox : Control
{
    [Export] public Label SpeakerLabel;
    [Export] public Label TextLabel;
    [Export] public VBoxContainer ChoiceContainer;
    [Export] public PackedScene ChoiceButtonPrefab;

    public void UpdateDialogue(string speaker, string text, List<Choice> choices)
    {
        SpeakerLabel.Text = LocalizationManager.Get(speaker);
        TextLabel.Text = LocalizationManager.Get(text);

        foreach (Node child in ChoiceContainer.GetChildren())
        {
            child.QueueFree();
        }

        if (choices != null)
        {
            foreach (var choice in choices)
            {
                var button = ChoiceButtonPrefab.Instantiate<Button>();
                button.Text = LocalizationManager.Get(choice.text);
                button.Pressed += () => EmitSignal("ChoiceSelected", choice.next);
                ChoiceContainer.AddChild(button);
            }
        }
    }
}