﻿using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class DialogueParser : MonoBehaviour 
{
	struct DialogueLine
	{
		public string name;
		public string content;
		public int pose;
		public string position;
		public string[] options;

		public DialogueLine(string Name, string Content, int Pose, string Position)
		{
			name = Name;
			content = Content;
			pose = Pose;
			position = Position;
			options = new string[0];
		}
	}

	List<DialogueLine> dialogueLines;

	// Use this for initialization
	void Start () 
	{
		string file = "Assets/Data/Dialogue";
		string sceneNum = EditorApplication.currentScene;
		sceneNum = Regex.Replace (sceneNum, "[^0-9]", "");

		file += sceneNum;
		file += ".txt";

		dialogueLines = new List<DialogueLine> ();

		LoadDialogue (file);

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	private void LoadDialogue(string fileName)
	{
		string line;
		StreamReader r = new StreamReader (fileName);

		using (r) 
		{
			do
			{
				line = r.ReadLine();
				if(line != null)
				{
					string[] lineData = line.Split(';');
					if(lineData[0] == "Player")
					{
						DialogueLine lineEntry = new DialogueLine(lineData[0], "", 0, "");
						lineEntry.options = new string[lineData.Length - 1];

						for(int i = 1; i < lineData.Length; i++)
						{
							lineEntry.options[i-1] = lineData[i];
						}
						dialogueLines.Add (lineEntry);
					}
					else
					{
						DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1], int.Parse(lineData[2]), lineData[3]);
						dialogueLines.Add(lineEntry);
					}
				}
			}while(line != null);
			r.Close();
		}
	}

	public string GetPosition(int lineNumber)
	{
		if (lineNumber < dialogueLines.Count) 
		{
			return dialogueLines[lineNumber].position;
		}
		return "";
	}

	public string GetName(int lineNumber)
	{
		if (lineNumber < dialogueLines.Count)
		{
			return dialogueLines[lineNumber].name;
		}
		return "";
	}

	public string GetContent(int lineNumber)
	{
		if (lineNumber < dialogueLines.Count)
		{
			return dialogueLines[lineNumber].content;
		}
		return "";
	}

	public int GetPose(int lineNumber)
	{
		if (lineNumber < dialogueLines.Count)
		{
			return dialogueLines[lineNumber].pose;
		}
		return 0;
	}

	public string[] GetOptions(int lineNumber)
	{
		if (lineNumber < dialogueLines.Count)
		{
			return dialogueLines[lineNumber].options;
		}
		return new string[0];
	}
}
