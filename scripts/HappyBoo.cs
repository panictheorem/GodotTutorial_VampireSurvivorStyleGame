using Godot;
using System;

public partial class HappyBoo : Node2D
{
    public AnimationPlayer AnimationPlayer { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void play_idle_animation()
	{
        AnimationPlayer.Play("idle");
	}
    public void play_walk_animation()
    {
        AnimationPlayer.Play("walk");
    }
}
