using Godot;

public partial class ChoiceManager : Node
{
    [Signal]
    public delegate void ChoiceMadeEventHandler(int nextId);

    public void OnChoiceSelected(int nextId)
    {
        GD.Print($"Choice made with nextId: {nextId}");
        EmitSignal(nameof(ChoiceMade), nextId);
    }
}