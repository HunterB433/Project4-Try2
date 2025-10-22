using Godot;
using System;

public partial class Lava : Node2D
{
	public override void _Ready()
	{
		GetNode<Area2D>("Area2D").BodyEntered += OnBodyEntered;
	}
	
	private void OnBodyEntered(Node body)
	{
		if (body.IsInGroup("player"))
		{
			GD.Print("Lava touched!");
			GameManager.ZeroBottles();
			GameManager.PlayerDied();
		}
	}
}
