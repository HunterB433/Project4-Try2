using Godot;
using System;

public partial class Bottle : Node2D
{
	private CpuParticles2D _particles;
	private Area2D _area;
	private bool _collected = false;

	public override void _Ready()
	{
		_particles = GetNode<CpuParticles2D>("Partics");
		_area = GetNode<Area2D>("Area2D");

		_area.BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node body)
	{
		if (_collected)
			return;

		if (body.IsInGroup("player"))
		{
			_collected = true;
			GameManager.AddBottle();

			_particles.Emitting = true;
			GetNode<Sprite2D>("Sprite2D").Visible = false;
			_area.GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;

			GetTree().CreateTimer(0.3).Timeout += () => QueueFree();
		}
	}
}
