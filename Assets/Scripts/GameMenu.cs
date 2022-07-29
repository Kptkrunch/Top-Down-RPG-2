using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {

	public GameObject theMenu;
	public GameObject[] menuWindows;
	// main menu stats
	private CharacterStats[] _playerStats;
	public TextMeshProUGUI[] nameTextArray, hpTextArray, mpTextArray, expTextArray, lvlTextArray, attTextArray, defTextArray;
	public Slider[] expBarSliders;
	public Image[] characterImage;
	public GameObject[] characterStatHolder;
	
	// status menu stats
	public TextMeshProUGUI[] nameStatus;
	public TextMeshProUGUI hpStatus, mpStatus, expStatus, nextExpStatus, lvlStatus, attStatus, defStatus;
	public Image imageStatus;

	private void Update() {
		OpenCloseMenu();
		UpdateTabs();
		
	}

	private void OpenCloseMenu() {
		if (Keyboard.current.tabKey.wasPressedThisFrame) {
			if (!theMenu.activeInHierarchy) {
				UpdateMainStats();
				UpdateStatsScreen(0);
				theMenu.SetActive(true);
				GameManager.Instance.gameMenuOpen = true;
			} else {
				theMenu.SetActive(false);
				GameManager.Instance.gameMenuOpen = false;
			}
		}
	}

	public void UpdateMainStats() {
		_playerStats = GameManager.Instance.playerStats;

		for (int i = 0; i < _playerStats.Length; i++) {

			if (_playerStats[i].gameObject.activeInHierarchy) {
				characterStatHolder[i].SetActive(true);

				nameTextArray[i].text = _playerStats[i].characterName;
				hpTextArray[i].text = $"HP: {_playerStats[i].currentHp}/{_playerStats[i].maxHp}";
				mpTextArray[i].text = $"MP: {_playerStats[i].currentMana}/{_playerStats[i].maxMana}";
				attTextArray[i].text = $"Att: {_playerStats[i].attackPower}";
				defTextArray[i].text = $"Def: {_playerStats[i].defense}";
				lvlTextArray[i].text = $"Lvl: {_playerStats[i].characterLevel}";
				expTextArray[i].text = $"{_playerStats[i].currentExp}/{_playerStats[i].expToLevel[_playerStats[i].characterLevel]}";
				expBarSliders[i].maxValue = _playerStats[i].expToLevel[_playerStats[i].characterLevel];
				expBarSliders[i].value = _playerStats[i].currentExp;
				characterImage[i].sprite = _playerStats[i].characterImage;
			} else {
				characterStatHolder[i].SetActive(false);
			}
		}
		
	}


	public void UpdateStatsScreen(int characterSelected) {

		for (int i = 0; i < _playerStats.Length; i++) {

			if (i == characterSelected) {
				hpStatus.text = $"HP: {_playerStats[i].currentHp}/{_playerStats[i].maxHp}";
				mpStatus.text = $"MP: {_playerStats[i].currentMana}/{_playerStats[i].maxMana}";
				expStatus.text = $"EXP: {_playerStats[i].currentExp}";
				nextExpStatus.text = $"NEXT: {_playerStats[i].expToLevel}";
				lvlStatus.text = $"Lvl: {_playerStats[i].characterLevel}";
				attStatus.text = $"ATT: {_playerStats[i].attackPower}";
				defStatus.text = $"DEF: {_playerStats[i].defense}";
				imageStatus.sprite = _playerStats[i].characterImage;
			}
		}
	}
	public void ToggleWindow(int windowNumber) {
		print("toggle window called");
		for (int i = 0; i < menuWindows.Length; i++) {

			if (i == windowNumber) {
				menuWindows[i].SetActive(!menuWindows[i].activeInHierarchy);
			} else {
				menuWindows[i].SetActive(false);
			}
		}
	}

	public void CloseMenu() {

		for (int i = 0; i < menuWindows.Length; i++) {
			menuWindows[i].SetActive(false);
		}
		
		theMenu.SetActive(false);

		GameManager.Instance.gameMenuOpen = false;
	}

	public void UpdateTabs() {
		_playerStats = GameManager.Instance.playerStats;
		for (int i = 0; i < _playerStats.Length; i++) {
			nameStatus[i].text = _playerStats[i].characterName;
		}
	}
}

