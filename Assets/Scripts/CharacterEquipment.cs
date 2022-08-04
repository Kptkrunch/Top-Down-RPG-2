using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterEquipment : MonoBehaviour {
	
	public Image wpnSprite, armSprite, currentCharSprite, newItemSprite;
	public TextMeshProUGUI curWpnName, curArmName, newItemName, 
							curWpnAttack, curArmorDefense,
							newWpnAttack, newArmorDefense,
							atkDifference, dfsDifference;

	public int wpnAtk, armDfs, newWpnAtkVal, newArmorDfsVal, atkDiff, dfsDiff;
	public static CharacterEquipment Instance;
	
	private void Start() {
		Instance = this;
	}

	private void Update() {
		GetCharacterStats(GameMenu.Instance.currentCharacterObj,
			GameMenu.Instance.curCharWeapon, 
			GameMenu.Instance.activeItem);
	}

	public void GetCharacterStats(CharacterStats curCharacter, Item curItem, Item newItem) {
		Debug.Log("getting character stats");
		
		if (curCharacter && curItem && newItem) {

			atkDiff = wpnAtk - newWpnAtkVal;
			Debug.Log($"atkDiff: {atkDiff}");
			dfsDiff = armDfs - newArmorDfsVal;
			Debug.Log($"armDiff: {dfsDiff}");

			atkDifference.text = atkDiff.ToString();
			dfsDifference.text = dfsDiff.ToString();
			
			curWpnName.text = curCharacter.equippedWeapon;
			curArmName.text = curCharacter.equippedArmor;
			newItemName.text = newItem.itemName;

			curWpnAttack.text = curItem.weaponAttack.ToString();
			curArmorDefense.text = curItem.armorDefense.ToString();
			newWpnAttack.text = newItem.weaponAttack.ToString();
			newArmorDefense.text = newItem.armorDefense.ToString();

			currentCharSprite.sprite = curCharacter.characterImage;
			wpnSprite.sprite = curCharacter.weaponSprite.sprite;
			armSprite.sprite = curCharacter.armorSprite.sprite;
		}
	}
}
