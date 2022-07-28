using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rigidbody2D;
	private Animator _animator;
	private Vector2 _moveInput;
	private bool _isMoving;

	public static PlayerController Instance;
	public string spawnLocationName;
	
	[SerializeField, Range(0f, 100f)] private float moveSpeed = 5f;
	void Awake() {
		PersistPlayer();
		DontDestroyOnLoad(gameObject);
		
		// initialize variables
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	private void Update() {
		UpdateWalkingAnimation();
	}

	private void FixedUpdate() {
		_rigidbody2D.velocity = _moveInput * moveSpeed;
	}

	void OnMove(InputValue value) {
		_moveInput = value.Get<Vector2>();
	}

	void OnFire() {
		Debug.Log("Woosh woosh");
	}

	private void UpdateWalkingAnimation() {
		_animator.SetFloat("Horizontal", _moveInput.x);
		_animator.SetFloat("Vertical", _moveInput.y);
		_isMoving = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon || Mathf.Abs(_rigidbody2D.velocity.y) > Mathf.Epsilon;
		_animator.SetBool("isMoving", _isMoving);
	}

	private void PersistPlayer() {
		if (!Instance) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}
	}
}

