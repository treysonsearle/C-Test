using System.Collections.Generic;
using Godot;

namespace StateMachine
{
   public class StateMachine : Node
   {
      [Signal]
      delegate void transitioned(string stateName);
      [Export]
      public NodePath initialState = new NodePath();
      public State state = new State();

      public async override void _Ready()
      {
         base._Ready();
         state = GetNode(initialState) as State;
         await ToSignal(Owner, "ready");
         var NodeChildren = GetChildren();
         var test = new Godot.Collections.Dictionary<string, object>();
         foreach (State child in GetChildren())
         {
            child.stateMachine = this;
            test.Add("test", child.stateMachine);
         }

         state.OnEnter(test);
      }
      public void UnhandledInput(InputEvent _event)
      {
         state.HandleInput(_event);
      }
      public override void _Process(float _delta)
      {
         base._Process(_delta);
         state.OnUpdate(_delta);
      }
      public override void _PhysicsProcess(float _delta)
      {
         state.OnPhysicsUpdate(_delta);
      }
      public void TransitionTo(string TargetStateName, Godot.Collections.Dictionary<string, object> _msg)
      {
         if (!HasNode(TargetStateName))
         {
            return;
         }
         state.OnExit();
         state = GetNode(TargetStateName) as State;
         state.OnEnter(_msg);
         EmitSignal("transitiioned", nameof(state));
      }
   }
}