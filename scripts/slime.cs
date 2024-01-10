using Godot;
using System;

public partial class slime : Node2D
{
    public AnimationPlayer AnimationPlayer { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void play_walk()
    {
        AnimationPlayer.Play("walk");
    }
    public void play_hurt()
    {
        AnimationPlayer.Play("hurt");
        AnimationPlayer.Queue("walk");
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
