using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 600.0f;
	public const float JumpVelocity = -400.0f;
    public HappyBoo HappyBoo { get; set; }

    public override void _Ready()
    {
		HappyBoo = GetNode<HappyBoo>("HappyBoo");
    }
    public override void _PhysicsProcess(double delta)
	{
		var direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Velocity = direction * Speed;
		MoveAndSlide();

		if(direction != Vector2.Zero)
		{
			HappyBoo.play_walk_animation();

        }
		else
		{
			HappyBoo.play_idle_animation();
		}
	}
}
