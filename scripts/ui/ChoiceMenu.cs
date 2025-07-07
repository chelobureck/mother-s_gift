using Godot;
using System.Collections.Generic;

public partial class ChoiceMenu : Control
{
    [Signal]
    public delegate void ChoiceMadeEventHandler(int nextId);

    [Export]
    public VBoxContainer ChoiceContainer;

    [Export]
    public PackedScene ChoiceButtonPrefab;

    public void PopulateChoices(List<Choice> choices)
    {
        GD.Print($"Populating choices: {choices.Count}");

        foreach (Node child in ChoiceContainer.GetChildren())
            child.QueueFree();

        foreach (var choice in choices)
        {
            var button = ChoiceButtonPrefab.Instantiate<Button>();
            button.Text = LocalizationManager.Get(choice.text);
            button.Pressed += () => EmitSignal(nameof(ChoiceMade), choice.next);
            ChoiceContainer.AddChild(button);
        }
    }
}
