using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public CharacterStats[] playerStats;
	public bool gameMenuOpen, dialogueActive, fadingInBetweenAreas;
	public string[] itemsHeld;
	public int[] itemQuantity;
	public Item[] referenceItems;
	public Vector2 mousePosition;
	private void Start() {
		PersistGameManager();
		DontDestroyOnLoad(gameObject);
	}

	private void Update() {

		if (gameMenuOpen || dialogueActive || fadingInBetweenAreas) {
			PlayerController.Instance.canMove = false;
		}
		else {
			PlayerController.Instance.canMove = true;
		}
		
		GetMouseInfo();
	}
	
	private void PersistGameManager() {
		if (!Instance) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}
	public Item GetItemDetails(string itemName) {

		for (int i = 0; i < referenceItems.Length; i++) {

			if (referenceItems[i].itemName == itemName) {
				return referenceItems[i];
			}
		}
		return null;
	}
	public void SortItems() {
		var itemAfterSpace = true;

		while (itemAfterSpace) {

			itemAfterSpace = false;
			for (int i = 0; i < itemsHeld.Length - 1; i++) {
				if (itemsHeld[i] == "") {
				
					itemsHeld[i] = itemsHeld[i + 1];
					itemsHeld[i + 1] = "";
					
					itemQuantity[i] = itemQuantity[i + 1];
					itemQuantity[i + 1] = 0;

					if (itemsHeld[i] != "") {
						itemAfterSpace = true;
					}
				}
			}
		}


	}
	public void AddItem(string itemToAdd) {
		bool foundItemSlot = false;
		int foundSlotIndex = 0;
		
		for (int i = 0; i < itemsHeld.Length; i++) {
			if (itemsHeld[i] == "" || itemsHeld[i] == itemToAdd) {
				foundSlotIndex = i;
				i = itemsHeld.Length;
				foundItemSlot = true;
			}
		}
		
		if (foundItemSlot) {
				
			bool itemExists = false;
			for (int i = 0; i < referenceItems.Length; i++) {
					
				if (referenceItems[i].itemName == itemToAdd) {
					itemExists = true;
					i = referenceItems.Length;
				}
			}

			if (itemExists) {
				itemsHeld[foundSlotIndex] = itemToAdd;
				itemQuantity[foundSlotIndex]++;
			} else {
				Debug.Log($"{itemToAdd} doesn't exits");
			}
			GameMenu.Instance.ShowItems();
		}
	}
	public void RemoveItem(string itemToRemove) {
		
		bool itemFound = false;
		int itemPosition = 0;
		
		for(int i = 0; i < itemsHeld.Length; i++) {
			if (itemsHeld[i] == itemToRemove) {
				itemFound = true;
				itemPosition = i;
				i = itemsHeld.Length;
			}
		}

		if (itemFound) {

			itemQuantity[itemPosition]--;

			if (itemQuantity[itemPosition] == 0) {
				itemsHeld[itemPosition] = "";
			} 
			
			GameMenu.Instance.ShowItems();
		} else {
			Debug.Log("Item not found");
		}
	}
	private void GetMouseInfo() {

		var wasOpened = false;

		if (GameMenu.Instance.charSelectPanel != null && GameMenu.Instance.menuWindows[0].activeInHierarchy) {
			
			mousePosition = new Vector2(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y);
			if (Mouse.current.rightButton.wasPressedThisFrame && !GameMenu.Instance.charSelectPanel.activeInHierarchy) {
				GameMenu.Instance.ShowCharacterChoices();
				wasOpened = true;
			}

			if (GameMenu.Instance.charSelectPanel.activeInHierarchy &&
			    !wasOpened &&
			    Mouse.current.rightButton.wasPressedThisFrame) {
				GameMenu.Instance.charSelectPanel.SetActive(false);
			}
		}

	}
		
}

