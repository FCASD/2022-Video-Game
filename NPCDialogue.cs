using System.Collections.Generic;

namespace TSAVideoGame
{
    public class NPCDialogue
    {
        public int Index;
        public List<InterfaceSelectionObject> InterfaceSelectionObjects;
        public List<NPCDialogue> NPCDialogues;
        public string DisplayText;

        public NPCDialogue(List<InterfaceSelectionObject> interfaceSelections,string displayText,int index, 
            List<NPCDialogue> dialogues=null){
            InterfaceSelectionObjects=interfaceSelections;
            DisplayText=displayText;
            Index=index;
            if(dialogues!=null){
                NPCDialogues=dialogues;
            }
        }
    }
}
