using UnityEngine;

public class PlayerLoader : MonoBehaviour {

	public GameObject player;
	void Awake() {
		if (!PlayerController.Instance) {
			Instantiate(player);
		}

	}
}

