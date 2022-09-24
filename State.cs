using System;
using Godot;

namespace StateMachine
{
   public class State : Node
   {
      public StateMachine stateMachine
      { get; set; }

      public void HandleInput(InputEvent _event)
      {
         return;
      }
      public void OnUpdate(float _delta)
      {
         return;
      }
      public void OnPhysicsUpdate(float _delta)
      {
         return;
      }
      public void OnEnter(Godot.Collections.Dictionary<string, object>? _msg)
      {
         return;
      }
      public void OnExit()
      {
         return;
      }
   }
}