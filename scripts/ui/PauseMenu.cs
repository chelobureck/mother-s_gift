using Godot;

public partial class PauseMenu : Control
{
    public void OnResumePressed()
    {
        GetTree().Paused = false;
        Hide();
        GD.Print("Game resumed");
    }

    public void OnQuitPressed()
    {
        GetTree().Quit();
    }
}