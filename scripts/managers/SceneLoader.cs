using Godot;

public partial class SceneLoader : Node
{
    public void LoadScene(string path)
    {
        GetTree().ChangeSceneToFile(path);
    }
}