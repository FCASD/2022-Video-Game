using Godot;
using System;

public class GameManager : Node
{
    public bool gamePaused=false;
    public static GameManager GlobalGameManager;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if(GlobalGameManager==null){
            GlobalGameManager=this;
        }else{
            QueueFree();
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
