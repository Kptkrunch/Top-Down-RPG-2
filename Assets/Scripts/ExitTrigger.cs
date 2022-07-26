using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class ExitTrigger : MonoBehaviour {

	public string scene;
	public string nextAreaSpawnPoint;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			PlayerController.Instance.nextAreaSpawnPoint = nextAreaSpawnPoint;
			SceneManager.LoadScene(scene, LoadSceneMode.Single);
		}
	}
}

