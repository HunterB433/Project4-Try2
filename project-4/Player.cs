using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float xSpeed = 175f;
	[Export] public float ySpeed = -335f;
	[Export] public float gravity = 980f;
	
	private AnimatedSprite2D animatedSprite;
	
	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;
		
		Vector2 direction = Vector2.Zero;
		if (Input.IsActionPressed("move_right"))
			direction.X += 1;
		if (Input.IsActionPressed("move_left"))
			direction.X -= 1;
			
		// Flip sprite Direction
		if (direction.X > 0)
			animatedSprite.FlipH = false;
		else if (direction.X < 0)
			animatedSprite.FlipH = true;
		
		velocity.X = direction.X * xSpeed;
		
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = ySpeed;
			
		// Animation
		if (Mathf.Abs(direction.X) > 0.1f)
		{
			if (animatedSprite.Animation != "Run")
			{
				animatedSprite.Play("Run");
			}
		}
		else
		{
			if (animatedSprite.Animation != "Idle")
			{
				animatedSprite.Play("Idle");
			}
		}
		
		Velocity = velocity;
		MoveAndSlide();
	}
}
