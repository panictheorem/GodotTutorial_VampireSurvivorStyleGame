using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public float Health { get; set; } = 100.0f;
    public float DamageRate { get; set; } = 5.0f;
    public const float Speed = 600.0f;
	public const float JumpVelocity = -400.0f;
    public HappyBoo HappyBoo { get; set; }
    public Area2D HurtBox { get; set; }
    public ProgressBar HealthBar { get; set; }

    [Signal]
	public delegate void HealthDepletedEventHandler();
    public override void _Ready()
    {
		HappyBoo = GetNode<HappyBoo>("HappyBoo");
        HurtBox = GetNode<Area2D>("HurtBox");
        HealthBar = GetNode<ProgressBar>("HealthBar");
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

		var overlappingMobs = HurtBox.GetOverlappingBodies();
		if(overlappingMobs.Count > 0)
		{
			Health -= DamageRate * overlappingMobs.Count * (float)delta;
			HealthBar.Value = Health;

            if (Health <= 0.0)
			{
				EmitSignal(SignalName.HealthDepleted);
            }
        }
	}
}
