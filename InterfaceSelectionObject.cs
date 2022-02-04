using Godot;
using System;

public class InterfaceSelectionObject
{
    public string SelectionText;
    public int SelectionIndex;
    public InterfaceSelectionObject(int index,string selectionText){
        SelectionText=selectionText;
        SelectionIndex=index;
    }
    public InterfaceSelectionObject(){

    }
}