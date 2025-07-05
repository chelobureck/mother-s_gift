using Godot;

public partial class SceneLoader : Node
{
    [Export]
    public string ScenePath = "";

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(ScenePath))
        {
            GD.Print($"Loading scene: {ScenePath}");
            GetTree().ChangeSceneToFile(ScenePath);
        }
        else
        {
            GD.PrintErr("Scene path is empty!");
        }
    }
}