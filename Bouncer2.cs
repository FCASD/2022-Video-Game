using Godot;
using System;
using System.Collections.Generic;
public class Bouncer2 : KinematicBody2D
{
    private List<NPCDialogue> npcDialogue;
    private string npcName;
    public override void _Ready()
    {
        InterfaceSelectionObject obj=new InterfaceSelectionObject(1,"Hello");
        InterfaceSelectionObject obj2=new InterfaceSelectionObject(2,"Nice to meet");
        InterfaceSelectionObject obj3=new InterfaceSelectionObject(3,"that ifs cool");
        InterfaceSelectionObject obj4=new InterfaceSelectionObject(-1,"children");
        npcDialogue=new List<NPCDialogue>{
            new NPCDialogue(new List<InterfaceSelectionObject>{obj}, "Hello",0),
            new NPCDialogue(new List<InterfaceSelectionObject>{obj2}, "hi",1),
            new NPCDialogue(new List<InterfaceSelectionObject>{obj3}, "Hello3",2),
            new NPCDialogue(new List<InterfaceSelectionObject>{obj4}, "Hello4",3),

        };
        
       
    }


    public void setNPCDialogue(){
        Interface.dialogueManager.npcDialogue=npcDialogue;
        Interface.dialogueManager.dialogueHeader=npcName;
    }
}
