using Godot;
using System;

namespace StateMachine
{
   public class Run : PlayerState
   {
      public void OnPhysicsUpdate()
      {
         if (!PlayerNode.IsOnFloor())
         {
            stateMachine.TransitionTo("Air", null);
            return;
         }
         float InputDirectionX = (Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left"));
         PlayerNode.velocity.x = PlayerNode.speed * InputDirectionX;
         PlayerNode.velocity.y = PlayerNode.gravity * delta;
         PlayerNode.velocity = PlayerNode.MoveAndSlide(PlayerNode.velocity, new Vector2(0, -1));
         if (Input.IsActionJustPressed("ui_up"))
         {
            stateMachine.TransitionTo("Air", null);
         }
         else if (Mathf.IsEqualApprox(InputDirectionX, 0.0f))
         {
            stateMachine.TransitionTo("Idle", null);
         }
      }

   }
}

