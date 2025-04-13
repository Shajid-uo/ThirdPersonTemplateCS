using Godot;
using System;
using TPTemplate.Const;

namespace TPTemplate;

public partial class TPPlayer : CharacterBody3D
{
	[Export]private float Speed = 5.0f;
	[Export]private float JumpVelocity = 4.5f;
	[Export]private float SensHorizontal = 0.5f;
	[Export]private float SensVertical = 0.5f;

	[Export]private Node3D OriginPoint;
	[Export]private Node3D CharcterOrigin;
	private AnimationPlayer mAnimPlayer;
	private float Gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

}
public partial class TPPlayer : CharacterBody3D{

    public override void _Ready()
    {
		Input.MouseMode = Input.MouseModeEnum.Captured;
        mAnimPlayer = GetNode<AnimationPlayer>("Charcter/mixamo_base/AnimationPlayer");
		CharcterOrigin = GetNode<Node3D>("Charcter");
    }

    public override void _Input(InputEvent evnt)
    {
        if(evnt is InputEventMouseMotion mouseMotion){
            RotateY(Mathf.DegToRad(-mouseMotion.Relative.X)*Mathf.Abs(SensHorizontal));
			CharcterOrigin.RotateY(Mathf.DegToRad(mouseMotion.Relative.X)*SensHorizontal);
			OriginPoint.RotateX(Mathf.DegToRad(-mouseMotion.Relative.Y)*Mathf.Abs(SensVertical));
		}
    }




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
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector(PConstant.INPUT_M_LEFT, PConstant.INPUT_M_RIGHT, PConstant.INPUT_M_UP, PConstant.INPUT_M_DOWN);
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{  
			if(mAnimPlayer.CurrentAnimation != "walking"){
                mAnimPlayer.Play("walking");
				CharcterOrigin.LookAt(GlobalPosition+direction);
			}
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{  
			if(mAnimPlayer.CurrentAnimation != "idle")
			{
			  mAnimPlayer.Play("idle");
			  
			}
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
