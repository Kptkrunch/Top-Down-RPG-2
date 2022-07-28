using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public string dialogueText;
	public string nameText;
	
	public GameObject dialogueBox;
	public GameObject nameBox;

	public TextMeshProUGUI dialogueTextBox;
	public TextMeshProUGUI nameTextBox;

	public string[] dialogueLines;

	public int currentLine = 0;

	private void Update() {
		if (dialogueLines.Length > 0) {
			dialogueTextBox.text = dialogueLines[currentLine];
		}

	}
}

