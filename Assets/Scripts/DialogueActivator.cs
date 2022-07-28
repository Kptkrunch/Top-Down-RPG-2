using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueActivator : MonoBehaviour {

	public string[] lines;
	public string npcName;
	public bool canActivate;
	private void Update() {
		if (canActivate && Keyboard.current.spaceKey.wasPressedThisFrame && !DialogueManager.Instance.dialogueBox.activeInHierarchy) {
			DialogueManager.Instance.ShowDialogue(lines, name);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			canActivate = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			canActivate = false;
			if (DialogueManager.Instance.dialogueBox.activeInHierarchy) {
				DialogueManager.Instance.dialogueBox.SetActive(false);
			}

			if (DialogueManager.Instance.nameBox.activeInHierarchy) {
				DialogueManager.Instance.nameBox.SetActive(false);
			}
		}
	}
}

