using Godot;

public partial class PuzzleManager : Node
{
    [Export]
    public string PuzzleScenePath = "";

    public void LoadPuzzle()
    {
        if (!string.IsNullOrEmpty(PuzzleScenePath))
        {
            GD.Print($"Loading puzzle scene: {PuzzleScenePath}");
            GetTree().ChangeSceneToFile(PuzzleScenePath);
        }
        else
        {
            GD.PrintErr("PuzzleScenePath is empty!");
        }
    }
}