using Godot;
using System;
using System.Collections.Generic;
public class Dialogue : Control
{
    public List<NPCDialogue> npcDialogue;
    [Export]
    public PackedScene InterfaceSelectableObject;
    public List<InterfaceSelection> Selections = new List<InterfaceSelection>();
    public override void _Ready()
    {
        
    }

    public void showDialogue(){
        GetNode<Popup>("Popup").Popup_();
        
        GetNode<Label>("Popup/Label").Text="test2";
        WriteDialogue(npcDialogue[0]);
    }
    public void WriteDialogue(NPCDialogue dialogue){
        GetNode<RichTextLabel>("Popup/RichTextLabel").Text=dialogue.DisplayText;
        foreach(var item in dialogue.InterfaceSelectionObjects){
            InterfaceSelection interfaceSelection = InterfaceSelectableObject.Instance() as InterfaceSelection;
            interfaceSelection.interfaceSelectionObject=item;
            GetNode<HBoxContainer>("Popup/HBoxContainer").AddChild(interfaceSelection);
            Selections.Add(interfaceSelection);
            interfaceSelection.SetSelected(false);
        };
    }
}
