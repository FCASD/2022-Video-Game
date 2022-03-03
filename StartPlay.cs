using Godot;

namespace TSAVideoGame
{
    public class StartPlay : Button
    {
        public void OnButtonPress(){
        
           
            GetTree().ChangeScene("Exposition.tscn");
        
        }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
     
        }
    }
}
