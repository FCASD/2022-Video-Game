using System.Collections.Generic;
using System.Linq;
using Godot;

namespace TSAVideoGame
{
    public class Dialogue : Control
    {
    
    
    
    
        int i =0;
        public List<NPCDialogue> npcDialogue;
        [Export]
        public PackedScene InterfaceSelectableObject;
        public List<InterfaceSelection> Selections = new List<InterfaceSelection>();
        private int currentSelectionIndex=0;
        public string dialogueHeader;
        public override void _Ready()
        {
        
        }

        public void showDialogue(){
            GetNode<Popup>("Popup").Popup_();
        
            GetNode<Label>("Popup/Label").Text=dialogueHeader;
            WriteDialogue(npcDialogue[0]);
        }
        public void WriteDialogue(NPCDialogue dialogue){
            foreach(Node item in GetNode<Node>("Popup").GetChildren()){
                if(item is Label||item is RichTextLabel||item is HBoxContainer||item is ColorRect){
                
                }else{
                
                    item.QueueFree();
                }
            }
            i=0;
            Selections=new List<InterfaceSelection>();
            GetNode<RichTextLabel>("Popup/RichTextLabel").Text=dialogue.DisplayText;
            foreach(var item in dialogue.InterfaceSelectionObjects){
                InterfaceSelection interfaceSelection = InterfaceSelectableObject.Instance() as InterfaceSelection;
                interfaceSelection.interfaceSelectionObject=item;
                GetNode<Popup>("Popup").AddChild(interfaceSelection);
                Selections.Add(interfaceSelection);
                interfaceSelection.SetSelected(false);
            
                interfaceSelection.GetChild<Label>(0).RectSize=new Vector2(300,50);
                interfaceSelection.GetChild<Label>(0).SetPosition(new Vector2(i*300,50));
            
                i++;
            };
        
            Selections[0].SetSelected(true);
            currentSelectionIndex=0;
            GameManager.GlobalGameManager.gamePaused=true;
        }
        public async override void _Process(float delta){
            if(GameManager.GlobalGameManager.gamePaused==true){
                if(Input.IsActionJustPressed("ui_left")){
                    foreach(var item in Selections){
                        item.SetSelected(false);
                    }
                    currentSelectionIndex--;
                
                    if(currentSelectionIndex<0){
                        currentSelectionIndex=0;
                    }
                
                    Selections[currentSelectionIndex].SetSelected(true);
                    i=currentSelectionIndex;
                }else if(Input.IsActionJustPressed("ui_right")){
                    if(GameManager.GlobalGameManager.gamePaused){
                        foreach(var item in Selections){
                            item.SetSelected(false);
                        }
                        currentSelectionIndex++;
                    
                        if(currentSelectionIndex>=Selections.Count){                                 
                            currentSelectionIndex = Selections.Count - 1;
                        }
                    
                        Selections[currentSelectionIndex].SetSelected(true);
                        Selections[currentSelectionIndex].GetChild<TextureRect>(1).SetPosition(new Vector2(i*150,80));
                        i=currentSelectionIndex;
                    }
                }else if(Input.IsActionJustPressed("ui_accept")){
                    await ToSignal(GetTree(),"idle_frame");
                    displayNext(Selections[currentSelectionIndex].interfaceSelectionObject.SelectionIndex);
                }
            }
        }
        private void shutDown(){
        
            foreach(Node item in GetNode<Node>("Popup").GetChildren()){
                if(item is Label||item is RichTextLabel||item is HBoxContainer||item is ColorRect){
                
                }else{
               
                    item.QueueFree();
                }
            }
            GetNode<Popup>("Popup").Hide();
            GameManager.GlobalGameManager.gamePaused=false;
        
        }
        private void displayNext(int index){
            if(npcDialogue.ElementAtOrDefault(index)==null||index==-1){
                shutDown();
            }else{
                WriteDialogue(npcDialogue[index]);
            }
        }
    }
}
