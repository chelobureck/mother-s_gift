using Godot;

public partial class PuzzleGenomeLogic : Node
{
    [Export]
    public string PuzzleName = "PuzzleGenome";

    public void CheckSolution()
    {
        GD.Print($"{PuzzleName}: CheckSolution called!");
    }
}