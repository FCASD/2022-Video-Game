using Godot;

namespace TSAVideoGame
{
    public class NPCText : Label
    {
        public static int count1=0;
        public static int count2=0;
        public static int count3=0;
   
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
            int count12=count1;
            int count22=count2;
            int count32=count3;
            
            
        }
        
       
        
        
        public void dialogueFinish(){
            Button response1 =GetNode<Button>("Response1");
            Button response2 =GetNode<Button>("Response2");
            Button response3 =GetNode<Button>("Response3");
            response1.Visible=false;
            response2.Visible=false;
            response3.Visible=false;
            this.Visible=false;
            



            
        }
       
    }
}
    
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

