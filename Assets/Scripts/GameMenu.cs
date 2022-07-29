using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	public GameObject theMenu;
	private CharacterStats[] _playerStats;
	public TextMeshProUGUI[] nameTextArray, hpTextArray, mpTextArray, expTextArray, lvlTextArray;
	public Slider[] expBarSliders;
	public Image[] characterImage;
	public GameObject[] characterStatHolder;
	

	private void Update() {
		OpenCloseMenu();
	}

	private void OpenCloseMenu() {
		if (Keyboard.current.tabKey.wasPressedThisFrame) {

			if (!theMenu.activeInHierarchy) {
				theMenu.SetActive(true);
				UpdateMainStats();
				GameManager.Instance.dialogueActive = true;
			} else {
				theMenu.SetActive(false);
				GameManager.Instance.dialogueActive = false;
			}
		}
	}

	public void UpdateMainStats() {
		_playerStats = GameManager.Instance.playerStats;

		for (int i = 0; i < _playerStats.Length; i++) {

			if (_playerStats[i].gameObject.activeInHierarchy) {
				characterStatHolder[i].SetActive(true);
			} else {
				characterStatHolder[i].SetActive(false);
			}
		}
		
	}
}

