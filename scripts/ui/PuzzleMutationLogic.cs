using Godot;

public partial class PuzzleMutationLogic : Node
{
    [Export]
    public string PuzzleName = "PuzzleMutation";

    public void CheckSolution()
    {
        GD.Print($"{PuzzleName}: CheckSolution called!");
    }
}
