using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitTrigger : MonoBehaviour {

	public string sceneToLoad;
	public string nextLocationSpawnPoint;
	[SerializeField] private float waitToLoad = 1f;
	public bool shouldLoadAfterFade;

	public AreaSpawnPoint areaSpawnPoint;

	private void Update() {
		if (shouldLoadAfterFade) {
			waitToLoad -= Time.deltaTime;
			
			if (waitToLoad <= 0) {
				shouldLoadAfterFade = false;
				SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		
		if (other.CompareTag("Player")) {

			shouldLoadAfterFade = true;
			UIFade.Instance.FadeToBlack();
			PlayerController.Instance.spawnLocationName = nextLocationSpawnPoint;
		}
	}
}

