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
	public bool isPerson;
	
	private void Start() {
		PersistDialogueManager();
	}

	private void Update() {
		UpdateToNextLine();
	}
	
	private void PersistDialogueManager() {
		if (!Instance) {
			Instance = this;
		} 
	}

	private void UpdateToNextLine() {
		if (dialogueBox.activeInHierarchy) {
			
			if (Keyboard.current.spaceKey.wasReleasedThisFrame) {
				if (_justStartedTalking == false) {
					currentLine++;
					Debug.Log($"dialogue Lines length {dialogueLines.Length}, and this is the array {dialogueLines}");
					
					if (currentLine >= dialogueLines.Length) {
						Debug.Log($"dialogue Lines length {dialogueLines.Length}, and this is the array {dialogueLines}");

						dialogueBox.SetActive(false);
						nameBox.SetActive(false);
						GameManager.Instance.dialogueActive = false;
					} else {
						dialogueText.text = dialogueLines[currentLine];
					}
				} else {
					_justStartedTalking = false;
				}
			}
		} else {
			_justStartedTalking = true;
		}
	}

	public void ShowDialogue(string[] newLines, string npcName) {
		Debug.Log($"show diag was called");

		dialogueLines = newLines;
		currentLine = 0;

		dialogueText.text = dialogueLines[currentLine];
		nameText.text = npcName;
		
		dialogueBox.SetActive(true);
		nameBox.SetActive(isPerson);

		GameManager.Instance.dialogueActive = true;
	}
	
	
}

