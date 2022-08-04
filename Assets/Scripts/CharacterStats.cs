using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class CharacterStats : MonoBehaviour {

	public string characterName;
	public int characterLevel = 1;
	public int currentExp;
	public int[] expToLevel;
	public int maxLevel = 100;
	public int baseExp = 100;
	[SerializeField, Range(1, 2)] private float increaseMultiplier = 1.1f;

	public int currentHp;
	public int maxHp = 100;
	public int currentMana;
	public int maxMana = 100;

	public int attackPower;
	public int defense;

	public string equippedWeapon;
	public int weaponAttPow;
	public Image weaponSprite;
	public string equippedArmor;
	public int armorDefPow;
	public Image armorSprite;

	public Sprite characterImage;

	private void Start() {
		PopulateExpGoals(increaseMultiplier);
	}

	private void Update() {
		// PopulateWepArmValues();
	}

	private void AddExp(int expToAdd) {
		currentExp += expToAdd;

		if (currentExp > expToLevel[characterLevel +1]) {
			characterLevel++;

			int attackIncrease = Random.Range(1, 3);
			int defenseIncrease = Random.Range(0, 2);
			attackPower += attackIncrease;
			defense += defenseIncrease;
			
			print($"Congrats!!! You've been promoted to level: {characterLevel}, AttackPower has risen by {attackIncrease}, Defense has risen by {defenseIncrease}");
			currentExp = 0;
		}
	}

	// private void PopulateWepArmValues() {
	// 	for (int i = 0; i < GameManager.Instance.referenceItems.Length; i++) {
	// 		
	// 		if (equippedWeapon == GameManager.Instance.referenceItems[i].itemName) {
	// 			weaponAttPow = GameManager.Instance.referenceItems[i].weaponAttack;
	// 			weaponSprite.sprite = GameManager.Instance.referenceItems[i].itemSprite;
	// 		}
	// 		
	// 		if (equippedArmor == GameManager.Instance.referenceItems[i].itemName) {
	// 			armorDefPow = GameManager.Instance.referenceItems[i].armorDefense;
	// 			armorSprite.sprite = GameManager.Instance.referenceItems[i].itemSprite;
	// 		}
	// 	}
	// }

	private void PopulateExpGoals(float multiplier) {
		print("exp goals populated");
		expToLevel = new int[maxLevel];
		expToLevel[1] = baseExp;

		for (int i = 2; i < expToLevel.Length; i++) {
			expToLevel[i] = Mathf.FloorToInt(expToLevel[i - 1] * multiplier);
		}
	}
}

