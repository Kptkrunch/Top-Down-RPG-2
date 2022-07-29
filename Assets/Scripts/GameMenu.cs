using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenu : MonoBehaviour {

	public GameObject theMenu;
	private void Update() {
		OpenCloseMenu();
	}

	private void OpenCloseMenu() {
		if (Keyboard.current.tabKey.wasPressedThisFrame) {

			if (!theMenu.activeInHierarchy) {
				theMenu.SetActive(true);
				GameManager.Instance.dialogueActive = true;
			}
			else {
				theMenu.SetActive(false);
				GameManager.Instance.dialogueActive = false;
			}
		}
	}
}

