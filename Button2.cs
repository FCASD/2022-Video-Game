using Godot;
using System;

public class Button2 : Button
{
    
     private string[] sentences = {"ding","yahahahahah","its rewind time","you know? if i could control rewind, i would want","Fortnite, and Marques Brownlee","yahahahah! thats hot! thats hot!"};

    int i =0;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
        this.Connect("pressed",this,"onButtonPress");
    }
    public void onButtonPress(){
        if(i<sentences.Length){
                //to add more sentences to exposition, add the sentence to the array
                Label ExpositionText=GetParent<Label>();
                ExpositionText.Text=sentences[i];
                i++;
                
        }else{
            
           GetTree().ChangeScene("Level1.tscn");
        }
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
