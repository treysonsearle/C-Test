using Godot;


namespace StateMachine
{
    public class PlayerState : State
    {
        public Node player;

        public override void _Ready()
        {

            base._Ready();
            ToSignal(Owner, "ready");
            player = Owner as Node;           
        }
    }
}
