using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		// Подключаем обработчики событий для кнопок
		GetNode<TextureButton>("CenterContainer/VBoxContainer/NewGameButton")
			.Connect("pressed", Callable.From(OnNewGameButtonPressed));
		GetNode<TextureButton>("CenterContainer/VBoxContainer/ChaptersButton")
			.Connect("pressed", Callable.From(OnChaptersButtonPressed));
		GetNode<TextureButton>("CenterContainer/VBoxContainer/OptionsButton")
			.Connect("pressed", Callable.From(OnOptionsButtonPressed));
		GetNode<TextureButton>("CenterContainer/VBoxContainer/QuitButton")
			.Connect("pressed", Callable.From(OnQuitButtonPressed));
		GetNode<TextureButton>("SettingsButton")
			.Connect("pressed", Callable.From(OnSettingsButtonPressed));
		GetNode<TextureButton>("QuestionMarkButton")
			.Connect("pressed", Callable.From(OnQuestionMarkButtonPressed));
	}

	private void OnNewGameButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/chapters/chapter1/Room_Hero.tscn");
	}

	private void OnChaptersButtonPressed()
	{
		GD.Print("Chapters - реализуй выбор глав");
		// Здесь твоя логика выбора уровня
	}

	private void OnOptionsButtonPressed()
	{
		GD.Print("Options - реализуй открытие настроек");
		// Здесь твоя логика открытия настроек
	}

	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}

	private void OnSettingsButtonPressed()
	{
		GD.Print("Settings - реализуй открытие настроек");
		// Здесь твоя логика открытия настроек
	}

	private void OnQuestionMarkButtonPressed()
	{
		GD.Print("Question Mark - реализуй справку");
		// Здесь твоя логика открытия справки
	}
} 
