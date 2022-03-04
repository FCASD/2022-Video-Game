using Godot;
using System;
using System.Collections.Generic;
///<summary>
///Class <c>DialogueChoice</c> creates a dialogue object with choices
///</summary>
public class DialogueChoice : Node
{
	private string prompt;
	private List<string> choices = new List<string>();
	private List<DialogueChoice> subChoices = new List<DialogueChoice>();
	private int currentLevel;
	public int lineNum;

	///<summary>
	///Constuctor <c>DialogueChoice</c> takes in an list of strings and the current line number
	///</summary>
	///<param name="lines">The list of lines in the script</param>
	///<param name="lineNum">The starting line for the script</param>
	public DialogueChoice(List<string> lines, int lineNum) {

		// TODO redo all of this to be better recursion

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

	///<summary>Checks the given line for any special cases</summary>
	///<param name="line">Line to check</param>
	///<returns>boolean (i forget why for rn)</returns>
	private bool checkLine(string line) {

		if (line.IndexOf('-') == 0) {
			GD.Print("Loss");
		}

		return false;
	}

	///<summary>Returns the prompt</summary>
	///<returns>Prompt in the form of a string</returns>
	public string getPrompt() {
		return this.prompt;
	}

	///<summary>Returns list of choices</summary>
	///<returns>List of <c>string</c></returns>
	public List<string> getChoices() {
		return this.choices;
	}

	///<summary>Returns sub choices</summary>
	///<returns>List of <c>DialogueChoices</c></returns>
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