using Godot;

public partial class PuzzleClassificationLogic : Node
{
    [Export]
    public string PuzzleName = "PuzzleClassification";

    public void CheckSolution()
    {
        GD.Print($"{PuzzleName}: CheckSolution called!");
    }
}
