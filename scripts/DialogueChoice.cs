using Godot;
using System;
using System.Collections.Generic;

public class DialogueChoice : Node
{
	private string prompt;
	private List<string> choices = new List<string>();
	private List<DialogueChoice> subChoices = new List<DialogueChoice>();
	private int currentLevel;
	public int lineNum;

	public DialogueChoice(List<string> lines, int lineNum) {

		this.lineNum = lineNum;
		this.currentLevel = ((string) lines[lineNum]).Count("\t");

		
		for (int i = lineNum; i < lines.Count; i++) {


			string line = ((string) lines[i]);


			if (line.Count("\t") == this.currentLevel) {


				if (line.Contains("\t?")) {
					choices.Add(line.TrimStart('\t').Substring(1));
					// lines.RemoveAt(i);

					if (i+1 < lines.Count && ((string) lines[i+1]).Count("\t") - 1 == line.Count("\t")) {
						// GD.Print(lines[i+1]);
						subChoices.Add(new DialogueChoice(lines, i+1));
					}
					else {
						subChoices.Add(null);
					}


					// i--;
				}

				else if (checkLine(line.TrimStart('\t'))) {
					break;
				}

				else {
					this.prompt = line.TrimStart('\t');
					// lines.RemoveAt(i);
					// i--;
				}


			}

			if (line.Count("\t") == this.currentLevel - 1) {
				break;
			}


		}


	}

	private bool checkLine(string line) {

		if (line.IndexOf('-') == 0) {
			GD.Print("Loss");
		}

		return false;
	}

	public string getPrompt() {
		return this.prompt;
	}

	public List<string> getChoices() {
		return this.choices;
	}

	public List<DialogueChoice> getSubChoices() {
		return this.subChoices;
	}

	public override string ToString() {

		string output = "\n" + this.prompt + "\n";
		output += "[ ";
		if (this.choices.Count > 0) {
			for (int i = 0; i < this.choices.Count - 1; i++) {
				output += this.choices[i] + ", ";
				output += this.subChoices[i] + "\n";
			}
			output += this.choices[this.choices.Count - 1] + " ";
				output += this.subChoices[this.choices.Count - 1] + "\n";
		}
		output += "]";
		return output;
	}

}