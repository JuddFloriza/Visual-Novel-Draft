using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour 
{
	DialogueParser parser;

	public string dialogue, characterName;
	public int lineNum;
	int pose;
	string position;
	string[] options;
	public bool playerTalking;
	List<Button> buttons = new List<Button>();

	public Text dialogueBox;
	public Text nameBox;
	public GameObject choiceBox;

	private bool isTyping = false;
	private bool autoDialogue = false;
	private int counter = 0;
	private float speed = 6.0f;
	// Use this for initialization
	void Start () 
	{
		dialogue = "";
		characterName = "";
		pose = 0;
		position = "L";
		playerTalking = false;
		parser = GameObject.Find ("DialogueParser").GetComponent<DialogueParser> ();
		lineNum = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && playerTalking == false) 
		{
			if (!isTyping) {
				Debug.Log ("Button being called.");
				dialogueBox.text = "";
				ShowDialogue ();
				lineNum++;
				isTyping = true;
				autoDialogue = false;
			} else {
				Debug.Log ("AUTO DIALOGUE");
				//ShowDialogue ();
				autoDialogue = true;
			}
		}

		UpdateUI ();
	}

	public void ShowDialogue()
	{
		ResetImages ();
		ParseLine ();
	}

	private void ResetImages()
	{
		if(characterName != "")
		{
			GameObject character = GameObject.Find(characterName);
			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			currSprite.sprite = null;
		}
	}

	private void ParseLine()
	{
		if(parser.GetName (lineNum) != "Player")
		{
			playerTalking = false;
			characterName = parser.GetName (lineNum);
			dialogue = parser.GetContent (lineNum);
			pose = parser.GetPose (lineNum);
			position = parser.GetPosition (lineNum);
			DisplayImages();
		}
		else
		{
			playerTalking = true;
			characterName = "";
			dialogue = "";
			pose = 0;
			position = "";
			options = parser.GetOptions(lineNum);
			CreateButtons();
		}
	}

	private void DisplayImages()
	{
		if(characterName != "")
		{
			GameObject character = GameObject.Find(characterName);

			SetSpritePositions(character);

			SpriteRenderer currSprite = character.GetComponent<SpriteRenderer>();
			currSprite.sprite = character.GetComponent<Character>().characterPoses[pose];
		}
	}

	private void SetSpritePositions(GameObject spriteObj)
	{
		if(position == "L")
		{
			spriteObj.transform.position = new Vector3(-43, 0);
		}
		else if(position == "R")
		{
			spriteObj.transform.position = new Vector3(43, 0);
		}
		spriteObj.transform.position = new Vector3 (spriteObj.transform.position.x, spriteObj.transform.position.y, 0);
	}

	private void CreateButtons()
	{
		for(int i = 0; i < options.Length; i++)
		{
			GameObject button = (GameObject) Instantiate(choiceBox);
			Button b = button.GetComponent<Button>();
			ChoiceButton cb = button.GetComponent<ChoiceButton>();

			cb.SetText(options[i].Split(':')[0]);
			cb.option = options[i].Split(':')[1];
			cb.box = this;
			b.transform.SetParent(this.transform);
			b.transform.localPosition = new Vector3(0, -25 + (i*50));
			b.transform.localScale = new Vector3(1,1,1);

			buttons.Add(b);
		}
	}

	private void UpdateUI()
	{
		if(!playerTalking)
		{
			ClearButtons();
		}

		if (autoDialogue) {
			dialogueBox.text = dialogue;
			isTyping = false;
			counter = 0;
		}
		else if(isTyping && Time.deltaTime * speed > 0.1f && playerTalking == false)
		{
//			if(Input.GetMouseButtonDown(0))
//			{
//				dialogueBox.text = dialogue;
//				isTyping = false;
//			}
			Debug.Log("This is triggered.");

			if(counter > dialogue.Length || dialogue.Length <= 0)
			{
				counter = 0;
				isTyping = false;
			}
			else
			{
				dialogueBox.text = dialogue.Substring(0, counter);
				counter++;
			}
		}
		//dialogueBox.text = dialogue;
		nameBox.text = characterName;
	}

	private void ClearButtons()
	{
		for(int i = 0; i < buttons.Count; i++)
		{
			Debug.Log("Clearing Buttons");
			Button b = buttons[i];
			buttons.Remove(b);
			Destroy(b.gameObject);
		}
	}
}
