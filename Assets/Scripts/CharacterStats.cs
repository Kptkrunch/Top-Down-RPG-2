using UnityEngine;
using UnityEngine.Serialization;

public class CharacterStats : MonoBehaviour {

	public string characterName;
	public int characterLevel = 1;
	public int currentExp = 0;

	public int currentHp;
	public int maxHp = 100;
	public int currentMana;
	public int maxMana = 100;

	public int attackPower;
	public int defense;

	public string equippedWeapon;
	public string equippedArmor;
	public Sprite characterImage;

}

