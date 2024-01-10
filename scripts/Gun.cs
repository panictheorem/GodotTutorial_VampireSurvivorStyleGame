using Godot;
using System;
using System.Linq;

public partial class Gun : Area2D
{
	[Export]
    public PackedScene BulletScene { get; set; }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		var enemiesInRange = GetOverlappingBodies();
		if (enemiesInRange.Count > 0) 
		{
			var targetEnemy = enemiesInRange.First();
			LookAt(targetEnemy.GlobalPosition);
		}
	}

	public void Shoot()
	{
		var bullet = BulletScene.Instantiate() as Bullet;
		var shootingPoint = GetNode<Marker2D>("%ShootingPoint");
        bullet.GlobalPosition = shootingPoint.GlobalPosition;
        bullet.GlobalRotation = shootingPoint.GlobalRotation;
		shootingPoint.AddChild(bullet);
    }

	public void _on_timer_timeout()
	{
		Shoot();
	}
}
