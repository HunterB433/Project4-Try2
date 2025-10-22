using Godot;
using System;

public partial class GameManager : Node
{
	public static int BottlesCollected { get; private set; } = 0;
	public static int BottleGoal { get; private set; } = 3;

	public static void AddBottle()
	{
		BottlesCollected++;
		GD.Print($"Bottle collected! ({BottlesCollected}/{BottleGoal})");

		if (BottlesCollected >= BottleGoal)
			BottlesCollected = 0;
			WinGame();
	}
	
	public static void ZeroBottles()
	{
		BottlesCollected = 0;
	}

	public static void PlayerDied()
	{
		GD.Print(" Player died!");
		SceneTree tree = (SceneTree)Engine.GetMainLoop();
		tree.ChangeSceneToFile("res://Scenes/LoseScreen.tscn");
	}

	public static void WinGame()
	{
		GD.Print(" You win!");
		SceneTree tree = (SceneTree)Engine.GetMainLoop();
		tree.ChangeSceneToFile("res://Scenes/WinScreen.tscn");
	}
}
