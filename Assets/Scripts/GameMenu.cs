using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
	
	[Header("UI Panels")]
	public GameObject theMenu;
	public GameObject charSelectPanel, charLoadoutPanel, charEquipComp;
	public GameObject[] menuWindows;

	[Header("Character UI Info")]
	private CharacterStats[] _playerStats;
	public TextMeshProUGUI[] nameTextArray, hpTextArray, mpTextArray, expTextArray, lvlTextArray, attTextArray, defTextArray;
	public Slider[] expBarSliders;
	public Image[] characterImage;
	public GameObject[] characterStatHolder;
	
	[Header("Stat Menu Stats")]
	public TextMeshProUGUI[] nameStatus;
	public TextMeshProUGUI hpStatus, mpStatus, expStatus, nextExpStatus, lvlStatus, attStatus, defStatus, wepStatus, armStatus, wepAtt, armDef;
	public Image imageStatus;

	[Header("UI Buttons")]
	public ItemButton[] itemStorageArray;
	public CharacterSelectButton[] characterSelectButtonArray;
	
	[Header("Item Process Info")]
	public string selectedItem;
	public Item activeItem;
	public Item curCharWeapon;
	public Item curCharArmor;
	
	[Header("Character Select Process Info")]
	public string selectedChar;
	public CharacterSelectButton activeCharacterButton;
	public CharacterStats currentCharacterObj;
	
	[Header("Item Data")]
	public TextMeshProUGUI itemName, itemDescription, useButtonText; 
	public static GameMenu Instance;
	
	private void Start() {
		Instance = this;
	}

	private void Update() {
		OpenCloseMenu();
		UpdateTabs();
		AddRemoveItemTest();
		OpenEquipmentComparison();
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
		
	}// populates player stats
	public void UpdateStatsScreen(int characterSelected) {

		currentCharacterObj = _playerStats[characterSelected];
		
		for (int i = 0; i < _playerStats.Length; i++) {

			if (i == characterSelected) {
				
				hpStatus.text = $"HP: {_playerStats[i].currentHp}/{_playerStats[i].maxHp}";
				mpStatus.text = $"MP: {_playerStats[i].currentMana}/{_playerStats[i].maxMana}";
				expStatus.text = $"Exp: {_playerStats[i].currentExp}";
				nextExpStatus.text = $"Next: {_playerStats[i].expToLevel[_playerStats[i].characterLevel]}";
				lvlStatus.text = $"Lvl: {_playerStats[i].characterLevel}";
				attStatus.text = $"Att: {_playerStats[i].attackPower}";
				defStatus.text = $"Def: {_playerStats[i].defense}";
				imageStatus.sprite = _playerStats[i].characterImage;
				wepStatus.text = $"Wpn: {_playerStats[i].equippedWeapon}";
				wepAtt.text = $"+{_playerStats[i].weaponAttPow} Att";
				armStatus.text = $"Arm: {_playerStats[i].equippedArmor}";
				armDef.text = $"+{_playerStats[i].armorDefPow} Def";
			}
		}
	}
	public void ToggleWindow(int windowNumber) {
		for (int i = 0; i < menuWindows.Length; i++) {

			if (i == windowNumber) {
				menuWindows[i].SetActive(!menuWindows[i].activeInHierarchy);

			} else {
				menuWindows[i].SetActive(false);
				charSelectPanel.SetActive(false);
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
	public void ShowItems() {

		GameManager.Instance.SortItems();
		
		for (int i = 0; i < itemStorageArray.Length; i++) {
			itemStorageArray[i].buttonIndex = i;

			if (GameManager.Instance.itemsHeld[i] != "") {
				
				itemStorageArray[i].buttonImage.gameObject.SetActive(true);
				itemStorageArray[i].buttonImage.sprite =
					GameManager.Instance.GetItemDetails(GameManager.Instance.itemsHeld[i]).itemSprite;
				itemStorageArray[i].quantityText.text = GameManager.Instance.itemQuantity[i].ToString();
			} else {
				
				itemStorageArray[i].buttonImage.gameObject.SetActive(false);
				itemStorageArray[i].quantityText.text = "";
			}
		}
	}
	public void ShowCharacterChoices() {

		if (!charSelectPanel.activeInHierarchy) {
			charSelectPanel.transform.position = GameManager.Instance.mousePosition;
		}
		
		for (int i = 0; i < characterSelectButtonArray.Length; i++) {
			characterSelectButtonArray[i].buttonImage.sprite = _playerStats[i].characterImage;
			characterSelectButtonArray[i].buttonIndex = i;
			characterSelectButtonArray[i].hpSlider.maxValue = _playerStats[i].maxHp;
			characterSelectButtonArray[i].hpSlider.value = _playerStats[i].currentHp;
			characterSelectButtonArray[i].mpSlider.maxValue = _playerStats[i].maxMana;
			characterSelectButtonArray[i].mpSlider.value = _playerStats[i].currentMana;
			characterSelectButtonArray[i].expSlider.maxValue = _playerStats[i].expToLevel[_playerStats[i].characterLevel];
			characterSelectButtonArray[i].expSlider.value = _playerStats[i].currentExp;
		}
		charSelectPanel.SetActive(true);
	}
	public void SelectItem(Item clickedItem) {
		
		activeItem = clickedItem;
		if (activeItem.isConsumable) {
			useButtonText.text = "Use";
		} else if (activeItem.isWeapon || activeItem.isArmor) {
			useButtonText.text = "Equip";
		}

		itemName.text = activeItem.itemName;
		itemDescription.text = activeItem.itemDescription;
	}
	public void DropItem() {
		if (activeItem) {
			GameManager.Instance.RemoveItem(activeItem.itemName);
		}
	}

	public void UseItem(int currentCharacter) {

		OpenCharacterSelection(currentCharacter);
		UpdateStatsScreen(currentCharacter);
		UpdateMainStats();
	}

	public void UnequipItem(int currentCharacter) {
		Debug.Log("stage 0");

		if (_playerStats[currentCharacter].equippedWeapon != "" || _playerStats[currentCharacter].equippedArmor != "") {
			Debug.Log("or conditional");
			
			if (Keyboard.current.ctrlKey.isPressed && Mouse.current.leftButton.wasPressedThisFrame) {
				Debug.Log($"Comparison should open {_playerStats[currentCharacter].equippedWeapon}");
			} 
		}
	}

	public void OpenCharacterSelection(int charSelected) {
		
		for (int i = 0; i < GameManager.Instance.itemsHeld.Length; i++) {

			if (activeItem.itemName == GameManager.Instance.itemsHeld[i]) {
				if (GameManager.Instance.itemQuantity[i] > 0) {
					activeItem.UseOrEquip(charSelected);
					ShowCharacterChoices();
				}
			}
		}
	}

	public void OpenEquipmentComparison() {

		if (CharacterEquipment.Instance) {
			if(Keyboard.current.shiftKey.wasPressedThisFrame && !charLoadoutPanel.activeInHierarchy) {
				Debug.Log("shiftKey pressed");
			
				CharacterEquipment.Instance.GetCharacterStats(currentCharacterObj, curCharWeapon, activeItem);
				charLoadoutPanel.SetActive(true);
			} 
		
			if(charLoadoutPanel && Keyboard.current.shiftKey.wasPressedThisFrame) {
			
				charLoadoutPanel.SetActive(false);
			}
		}

	}

	public void AddRemoveItemTest() {
		if (Keyboard.current.gKey.wasPressedThisFrame) {
			Debug.Log("Cherries");
			GameManager.Instance.AddItem("Cherries");
			GameManager.Instance.AddItem("Makeshift Sword");
			GameManager.Instance.RemoveItem("MP Potion");
			GameManager.Instance.RemoveItem("Iron Sword");
		}
	}
}

