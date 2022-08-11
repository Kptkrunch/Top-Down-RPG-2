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

	public void UpdateComparisonPanel(CharacterStats curCharacter) {

			Debug.Log("getting character stats");
			Debug.Log($"character weapon: {curCharacter.equippedWeapon}");
			Debug.Log($"test item: {GameMenu.Instance.activeItem.itemName}");
	}
}
