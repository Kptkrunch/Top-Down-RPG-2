using UnityEngine;

public class Item : MonoBehaviour {
	
	[Header("Item Type")]
	public bool isConsumable;
	public bool isWeapon;
	public bool isArmor;

	[Header("Item Details")]
	public string itemName;
	public string itemDescription;

	public int itemValue;
	public Sprite itemSprite;
	
	[Header("Item Details")]
	public int itemPotency;
	public bool changeHp;
	public bool changeMp;
	public bool changeStrength;

	[Header("Weapon and Armor Details")]
	public int weaponAttack;
	public int armorDefense;
	
	void OnTriggerEnter2D(Collider2D other) {

		if (other.CompareTag("Player")) {
			GameManager.Instance.AddItem(itemName);
			Destroy(gameObject);
		}
	}

	public void UseOrEquip(int selectedChar) {
		
		Debug.Log(selectedChar);
		CharacterStats charSelected = GameManager.Instance.playerStats[selectedChar];

		if (isConsumable) {
			if (changeHp) {
				charSelected.currentHp += itemPotency;
				if (charSelected.currentHp > charSelected.maxHp) {
					charSelected.currentHp = charSelected.maxHp;
				}
			}
			if (changeMp) {
				charSelected.currentMana += itemPotency;
				if (charSelected.currentMana > charSelected.maxMana) {
					charSelected.currentMana = charSelected.maxMana;
				}
			}
		}

		if (isWeapon) {
			if (charSelected.equippedWeapon != "") {
				GameManager.Instance.AddItem(charSelected.equippedWeapon);
			}

			charSelected.equippedWeapon = itemName;
			charSelected.attackPower += weaponAttack;
		}
		
		if (isArmor) {
			if (charSelected.equippedArmor != "") {
				GameManager.Instance.AddItem(charSelected.equippedArmor);
			}

			charSelected.equippedArmor = itemName;
			charSelected.defense += armorDefense;
		}
		GameMenu.Instance.DropItem();
	}

	public void Unequip(int selectedChar) {
		CharacterStats charSelected = GameManager.Instance.playerStats[selectedChar];
	
		if (isWeapon) {
			charSelected.attackPower -= charSelected.weaponAttPow;
			charSelected.weaponAttPow = 0;
			GameManager.Instance.AddItem(charSelected.equippedWeapon);
			charSelected.equippedWeapon = "";
		}
		
		if (isArmor) {
			charSelected.defense -= charSelected.armorDefPow;
			charSelected.armorDefPow = 0;
			GameManager.Instance.AddItem(charSelected.equippedArmor);
			charSelected.equippedArmor = "";
		}
	
	}
}

