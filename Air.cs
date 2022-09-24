using Godot;
using System;

 namespace StateMachine {
    public class Air : State
    {
        public void OnEnter()
        {
            Owner.velocity = Vector2().ZERO;
        }
        public void OnUpdate()
        {
            if(!Owner.IsOnFloor())
            {
                stateMachine.TransitionTo("Air");
                return;
            }
        }
    }  
}

