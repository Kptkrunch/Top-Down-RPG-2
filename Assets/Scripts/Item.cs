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

}

