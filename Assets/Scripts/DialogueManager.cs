using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour {
	
	public GameObject dialogueBox;
	public TextMeshProUGUI dialogueText;
	public GameObject nameBox;
	public TextMeshProUGUI nameText;

	public string[] dialogueLines;
	public int currentLine = 0;

	public static DialogueManager Instance;
	private bool _justStartedTalking;

	private void Start() {
		PersistDialogueManager();
	}

	private void Update() {
		UpdateToNextLine();
	}
	
	private void PersistDialogueManager() {
		if (!Instance) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}

	private void UpdateToNextLine() {
		if (dialogueBox.activeInHierarchy) {
			
			if (Keyboard.current.spaceKey.wasReleasedThisFrame) {
				if (_justStartedTalking == false) {
					currentLine++;
					Debug.Log($"currentLine: {currentLine}");
					if (currentLine >= dialogueLines.Length) {
						dialogueBox.SetActive(false);
						nameBox.SetActive(false);
					}
					else {
						dialogueText.text = dialogueLines[currentLine];
					}
				}
				else {
					_justStartedTalking = false;
				}
			}
		}
		else {
			_justStartedTalking = true;
		}
	}

	public void ShowDialogue(string[] newLines, string npcName) {
		dialogueLines = newLines;
		currentLine = 0;

		dialogueText.text = dialogueLines[0];
		nameText.text = npcName;
		
		dialogueBox.SetActive(true);
		nameBox.SetActive(true);
	}
	
	
}

