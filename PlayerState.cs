using Godot;


namespace StateMachine
{
   public class PlayerState : State
   {
      public Player PlayerNode
      {
         get { return PlayerNode; }
         set { PlayerNode = value; }
      }
      public override void _Ready()
      {
         base._Ready();
         ToSignal(Owner, "ready");
         PlayerNode = Owner as Player;
      }
   }
}
