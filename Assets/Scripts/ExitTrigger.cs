using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitTrigger : MonoBehaviour {

	public string sceneToLoad;
	public string nextLocationSpawnPoint;

	public AreaSpawnPoint areaSpawnPoint;

	private void Start() {
		//areaSpawnPoint.spawnPointName = fromAreaName;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {

			SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
			PlayerController.Instance.spawnLocationName = nextLocationSpawnPoint;
		}
	}
}

