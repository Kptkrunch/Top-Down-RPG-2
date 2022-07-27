using UnityEngine;

public class AreaSpawnPoint : MonoBehaviour {

	public string spawnPointName;
	void Start() {

		if (spawnPointName == PlayerController.Instance.spawnLocationName) {
			PlayerController.Instance.transform.position = transform.position;
		}
		
		UIFade.Instance.FadeFromBlack();
	}
}

