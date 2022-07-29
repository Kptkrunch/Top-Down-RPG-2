using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {
	public static UIFade Instance;

	public Image fadeScreen;
	[SerializeField] private bool fadeToBlack;
	[SerializeField] private bool fadeFromBlack;
	[SerializeField, Range(0f, 100f)] private float fadeSpeed = 50f;

	private void Start() {

		PersistObject();
		DontDestroyOnLoad(gameObject);
	}

	private void Update() {
		UIFadeEvent();
	}

	public void FadeToBlack() {
		Debug.Log("fading to black");
		fadeToBlack = true;
		fadeFromBlack = false;
	}

	public void FadeFromBlack() {
		fadeFromBlack = true;
		fadeToBlack = false;
	}

	private void PersistObject() {
		if (!Instance) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}

	private void UIFadeEvent() {
		if (fadeToBlack) {
			fadeScreen.color =
				new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
			if (fadeScreen.color.a == 1.0f) {
				fadeToBlack = false;
			}
		}

		if (fadeFromBlack) {
			fadeScreen.color =
				new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f,fadeSpeed * Time.deltaTime));
			if (fadeScreen.color.a == 0.0f) {
				fadeFromBlack = false;
			}
		}
	}
}

