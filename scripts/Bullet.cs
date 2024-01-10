using Godot;
using System;

public partial class Bullet : Area2D
{
	public float TravelledDistance { get; set; } = 0.0f;
    public float Speed { get; set; } = 1000.0f;
	public float Range { get; set; } = 1200.0f;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var direction = Vector2.Right.Rotated(Rotation);
		Position += direction * Speed * (float)delta;
		TravelledDistance += Speed * (float)delta;

		if(TravelledDistance > Range)
		{
			QueueFree();
		}
    }

	public void _on_body_entered(Node2D body)
	{
		QueueFree();
		var enemy = body as Mob;
		if(enemy != null)
		{
			enemy.TakeDamage();
		}
	}
}
