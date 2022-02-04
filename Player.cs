using Godot;
using System;

public class Player : KinematicBody2D
{
    public override void _Ready() {
		GD.Print("Player loaded");
	}


  public override void _Process(float delta){
	  float SPEED = 10;
	  if(Input.IsKeyPressed((int)KeyList.W)){
		  this.Position +=new Vector2(0,-SPEED);
		  
	  }
	  if(Input.IsKeyPressed((int)KeyList.S)){
		  this.Position +=new Vector2(0,SPEED);
		  
	  }
	  if(Input.IsKeyPressed((int)KeyList.A)){
		  this.Position +=new Vector2(-SPEED,0);
		  
	  }
	  if(Input.IsKeyPressed((int)KeyList.D)){
		  this.Position +=new Vector2(SPEED,0);
		  
	  }
      if(Input.IsKeyPressed((int)KeyList.E)){
            if(GetNode<RayCast2D>("RayCastLeft").IsColliding()){
                showBouncerDialogue();
            }else if(GetNode<RayCast2D>("RayCastRight").IsColliding()){
                showBouncerDialogue();
          }
          //make raycastup and down
      } 
  }
  private void showBouncerDialogue(){
      Node obj = (Node)GetNode<RayCast2D>("RayCastRight").GetCollider();
                if(obj is Bouncer){
                    Bouncer bouncer = obj as Bouncer;
                    bouncer.setBouncerDialogue();
                    Interface.dialogueManager.showDialogue();
                    
                }
  }
}
