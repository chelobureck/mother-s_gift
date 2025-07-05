using Godot;

public partial class PuzzleManager : Node
{
    public void LoadPuzzle(string puzzleScene)
    {
        GetTree().ChangeSceneToFile(puzzleScene);
    }
}