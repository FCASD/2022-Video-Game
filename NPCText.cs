using Godot;
using System;

public class NPCText : Label
{
    
   
     static int num=100;
     
    public override void _Ready()
    {
        dialogue("your mom","response1","response2","response3",0);
        
    }
    public void setText2(string ex){
        this.Text=ex;
    }
    public void invisible(){
        
        this.Visible=false;
    }
    
    public void dialogue(string Npctext, string response12,string response22,string response32, int check){
       
        if(check==1){
            num=1;
            
            GD.Print(GetPath());
             Button response1 =GetNode<Button>("Response1");
             Button response2 =(Button)GetNode<Button>("Response2");
             Button response3 =(Button)GetNode<Button>("Response3");
             response1.Visible=false;
             response2.Visible=false;
             response3.Visible=false;
            this.Visible=false;
            
        }else if(check==2){
            num=2;
            
        }else if(check==3){
            num=3;
            
        }else if(check==0){
            Button response1 =(Button)GetChild(0);
            Button response2 =(Button)GetChild(1);
            Button response3 =(Button)GetChild(2);
            
            
            
            response1.Text=response12;
            response2.Text=response22;
            response3.Text=response32;
            this.Text=Npctext; 
            response1.Visible=true;
            response2.Visible=true;
            response3.Visible=true;
            this.Visible=true;
        }
        
       
        
        }
       
    }
    
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

