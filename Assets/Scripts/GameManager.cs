using System;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;
	public CharacterStats[] playerStats;
	private void Start() {
		PersistGameManager();
		DontDestroyOnLoad(gameObject);
	}
	
	private void PersistGameManager() {
		if (!Instance) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}
}

