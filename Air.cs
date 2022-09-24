using Godot;
using System;

namespace StateMachine
{
   public class Air : PlayerState
   {
      public void OnEnter(Godot.Collections.Dictionary<string, object>? _msg)
      {
         if (_msg.ContainsKey("do_jump"))
         {
            PlayerNode.GetFloorVelocity.y = -PlayerNode.jumpImpulse;
         }

      }
      public override void _PhysicsProcess(float delta)
      {
         float InputDirectionX = (Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"));
         PlayerNode.velocity.y = PlayerNode.speed * InputDirectionX;
         PlayerNode.velocity.y = PlayerNode.gravity * delta;
         PlayerNode.velocity = PlayerNode.MoveAndSlide(PlayerNode.velocity, new Vector2(0, -1));
         if (Mathf.IsEqualApprox(InputDirectionX, 0.0f))
         {
            stateMachine.TransitionTo("Idle", null);
         }
         else
         {
            stateMachine.TransitionTo("Run", null);
         }
      }
   }
}

