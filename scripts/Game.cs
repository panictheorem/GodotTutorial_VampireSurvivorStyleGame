using Godot;
using System;

public partial class Game : Node2D
{
    public PathFollow2D EnemySpawnPath { get; set; }
    [Export]
    public PackedScene MobScene { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        EnemySpawnPath = GetNode<PathFollow2D>("%PathFollow2D");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}

    public void SpawnMob()
    {
        var mob = MobScene.Instantiate() as Mob;
        EnemySpawnPath.ProgressRatio = GD.Randf();
        mob.GlobalPosition = EnemySpawnPath.GlobalPosition;
        AddChild(mob);
    }

    public void _on_mob_timer_timeout()
    {
        SpawnMob();
    }

    public void _on_player_health_depleted()
    {
        var gameOver = GetNode<CanvasLayer>("GameOver");
        gameOver.Visible = true;
        GetTree().Paused = true;
    }
}
