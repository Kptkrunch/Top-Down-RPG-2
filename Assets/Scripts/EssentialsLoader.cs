using UnityEngine;

public class EssentialsLoader : MonoBehaviour {

	public GameObject uiScreen;
	public GameObject player;

	private void Start() {
		if (!UIFade.Instance) {
			Instantiate(uiScreen);
		}

		if (!PlayerController.Instance) {

			PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
			PlayerController.Instance = clone;
		}
	}
}

