using Godot;

namespace TSAVideoGame
{
    public class InterfaceSelection : Node
    {
        public bool Selected =false;
        public InterfaceSelectionObject interfaceSelectionObject=new InterfaceSelectionObject(0,"");
        public override void _Ready()
        {
       
            this.GetNode<Label>("Label").Text = interfaceSelectionObject.SelectionText;
        }

        public void SetSelected(bool selected){
            Selected=selected;
            if(Selected){
                GetNode<TextureRect>("TextureRect").Visible=true;
            
            }else{
                GetNode<TextureRect>("TextureRect").Visible=false;
            
            }

        }
    }
}

