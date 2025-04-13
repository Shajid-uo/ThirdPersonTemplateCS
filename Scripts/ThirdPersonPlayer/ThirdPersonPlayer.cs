using Godot;
using System;
/*
public partial class TPPlayer : CharacterBody3D
{
	public const float TPSpeed = 5.0f;
	public const float TPJumpVelocity = 4.5f;

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = TPJumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * TPSpeed;
			velocity.Z = direction.Z * TPSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, TPSpeed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, TPSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
*/