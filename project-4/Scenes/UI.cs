using Godot;
using System;

public partial class UI : CanvasLayer
{
	private Label _bottleLabel;

	public override void _Ready()
	{
		_bottleLabel = GetNode<Label>("BottleLabel");
		UpdateBottleLabel();
	}

	public override void _Process(double delta)
	{
		UpdateBottleLabel();
	}

	private void UpdateBottleLabel()
	{
		_bottleLabel.Text = $"Bottles: {GameManager.BottlesCollected}/{GameManager.BottleGoal}";
	}
}
