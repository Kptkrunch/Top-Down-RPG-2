using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public CharacterStats[] playerStats;
	public bool gameMenuOpen, dialogueActive, fadingInBetweenAreas;
	
	private void Start() {
		PersistGameManager();
		DontDestroyOnLoad(gameObject);
	}

	private void Update() {
		
		if (gameMenuOpen || dialogueActive || fadingInBetweenAreas) {
			PlayerController.Instance.canMove = false;
		}
		else {
			PlayerController.Instance.canMove = true;
		}
	}

	private void PersistGameManager() {
		if (!Instance) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}
}

