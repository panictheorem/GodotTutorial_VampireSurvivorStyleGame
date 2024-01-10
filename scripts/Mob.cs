using Godot;
using System;

public partial class Mob : CharacterBody2D
{
	public const float Speed = 300.0f;
	public int Health { get; set; } = 3;
    public slime Slime { get; set; }
    [Export]
    public Player Player { get; set; }
    [Export]
    public PackedScene SmokeExplosionScene { get; set; }

    public override void _Ready()
    {
		Player = GetNode<Player>("/root/Game/Player");
        Slime = GetNode<slime>("Slime");
		Slime.play_walk();
    }
    public override void _PhysicsProcess(double delta)
	{
		var direction = GlobalPosition.DirectionTo(Player.GlobalPosition);
		Velocity = direction * Speed;
		MoveAndSlide();
	}

	public void TakeDamage()
	{
		Slime.play_hurt();
		Health -= 1;
		if(Health == 0)
		{
			QueueFree();
			var smokeExplosion = SmokeExplosionScene.Instantiate() as Node2D;
			var parent = GetParent();
			parent.AddChild(smokeExplosion);
			smokeExplosion.GlobalPosition = GlobalPosition;

        }

		GD.Print($"Slime {Health}");
    }
}
