
using Godot;
using System;

public class InterfaceSelection : Node
{
    public bool Selected =false;
    public InterfaceSelectionObject interfaceSelectionObject;
    public override void _Ready()
    {
        this.GetNode<Label>("Label").Text=interfaceSelectionObject.SelectionText;
    }

    public void SetSelected(bool selected){
        Selected=selected;
    }
}

