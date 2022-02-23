using Godot;
using System;
using System.Collections.Generic;

public class Dialogue : Node
{
	private List<string> dialogueList = new List<string>();

	public override void _Ready()
	{

		string sceneFilename = GetPath();
		// GD.Print(sceneFilename);
		sceneFilename = sceneFilename.Split('/')[2]; // Need to change 3 when prefab is done
		GD.Print("Loading Dialogue...");

		try{
			string[] readLines = System.IO.File.ReadAllLines($"{sceneFilename}.md");

			for (int i = 0; i < readLines.Length; i++) {
				if(!readLines[i].Contains("\t") && readLines[i].Equals(GetParent().Name)) {
					i++;
					dialogueList.Add(readLines[i]);
					while (readLines[i].Contains("\t")) {
						i++;
						dialogueList.Add(readLines[i]);
					}
				}
			}

			DialogueChoice dialog = new DialogueChoice(dialogueList, 0);



			GD.Print(dialog.ToString());

			GD.Print("Dialogue Loaded.");

		}
		catch (Exception e) {
			GD.Print("Error " + e);
		}

	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
