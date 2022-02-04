using Godot;
using System;

public class Player : AnimatedSprite
{
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
	}


  public override void _Process(float delta){
	  float SPEED = 1;
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
	  
  }
}
