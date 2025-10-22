using Godot;
using System;

public partial class Button : Godot.Button
{
	private void OnPressed()
	{
		SceneTree tree = (SceneTree)Engine.GetMainLoop();
		tree.ChangeSceneToFile("res://Scenes/Main.tscn");
	}
}
