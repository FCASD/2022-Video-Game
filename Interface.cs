using Godot;
using System;

public class Interface : CanvasLayer
{
    public static Dialogue dialogueManager;
    public override void _Ready()
    {
        
        dialogueManager=GetNode("Dialogue") as Dialogue;
        
    }


//  public override void _Process(float delta)
//  {
//      
//  }
}
