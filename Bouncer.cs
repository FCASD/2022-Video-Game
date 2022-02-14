using System.Collections.Generic;
using Godot;

namespace TSAVideoGame
{
    public class Bouncer : RigidBody2D
    {
        [Export] public bool facingRight;

        private List<NPCDialogue> _npcDialogue;
        private string _npcName;

        public override void _Ready()
        {
            _npcName = "Bouncer";

            InterfaceSelectionObject obj = new InterfaceSelectionObject(1, "Welcome");
            InterfaceSelectionObject obj2 = new InterfaceSelectionObject(2, "Hello");
            InterfaceSelectionObject obj3 = new InterfaceSelectionObject(-1, "What is gucci fam");

            _npcDialogue = new List<NPCDialogue>
            {
                new NPCDialogue(new List<InterfaceSelectionObject> {obj, obj2}, "#relatable", 0),
                new NPCDialogue(new List<InterfaceSelectionObject> {obj2, obj3}, "your welcome", 1),
                new NPCDialogue(new List<InterfaceSelectionObject> {obj3}, "hello epic gamer", 2),
            };

            //the player would have the choice to say either obj or obj2, since #relatable is the first in the list, if they say welcome, npc would response with your welcome
        }

        public void SetNpcDialogue()
        {
            Interface.dialogueManager.npcDialogue = _npcDialogue;
            Interface.dialogueManager.dialogueHeader = _npcName;
        }
    }
}