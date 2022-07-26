using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitTrigger : MonoBehaviour {

	public string _scene;

	private void OnTriggerEnter2D(Collider2D other) {
		
		Debug.Log("trigger!!!");
		if (other.CompareTag("Player")) {
			SceneManager.LoadScene(_scene, LoadSceneMode.Single);
		}
	}
}

