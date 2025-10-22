using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export] public float Speed = 100f;
	[Export] public float DetectionRadius = 200f;
	[Export] public float CircleRadius = 50f;
	[Export] public float RotationSpeed = 1f;

	private Node2D _player;
	private Vector2 _center;
	private float _angle = 0f;

	public override void _Ready()
	{
		_player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		_center = GlobalPosition;
	}

	public override void _Process(double delta)
	{
		if (_player == null) return;

		float distance = GlobalPosition.DistanceTo(_player.GlobalPosition);

		if (distance < DetectionRadius)
		{
			Vector2 dir = (_player.GlobalPosition - GlobalPosition).Normalized();
			Velocity = dir * Speed;
		}
		else
		{
			_angle += (float)(RotationSpeed * delta);
			Vector2 offset = new Vector2(Mathf.Cos(_angle), Mathf.Sin(_angle)) * CircleRadius;
			Vector2 target = _center + offset;
			Vector2 dir = (target - GlobalPosition).Normalized();
			Velocity = dir * (Speed * 0.5f);
		}
		
		if (distance < 15)
		{
			GameManager.ZeroBottles();
			GameManager.PlayerDied();
		}

		MoveAndSlide();
	}
}
