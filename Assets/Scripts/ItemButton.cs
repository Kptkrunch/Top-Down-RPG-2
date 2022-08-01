using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ItemButton : MonoBehaviour {

	public Image buttonImage;
	public TextMeshProUGUI quantityText;
	public int buttonIndex;
	
	void Awake() {
		
	}

	public void Press() {

		if (GameManager.Instance.itemsHeld[buttonIndex] != "") {
			GameMenu.Instance.SelectItem(
				GameManager.Instance.GetItemDetails(GameManager.Instance.itemsHeld[buttonIndex]));
		}
	}
}

