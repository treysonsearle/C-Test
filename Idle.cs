using Godot;
using System;

namespace StateMachine
{
   public class Idle : PlayerState
   {
      public void OnEnter(Godot.Collections.Dictionary<string, object>? _msg)
      {
         PlayerNode.velocity = Vector2.Zero;
      }
      public override void _PhysicsProcess(float delta)
      {
         base._PhysicsProcess(delta);
         if (!PlayerNode.IsOnFloor())
         {
            stateMachine.TransitionTo("Air", null);
            return;
         }
         if (Input.IsActionJustPressed("ui_up"))
         {
            stateMachine.TransitionTo("Air", null);
         }
         else if (Input.IsActionJustPressed("ui_left") || Input.IsActionJustPressed("ui_right"))
         {
            stateMachine.TransitionTo("Run", null);
         }
      }
   }
}

