using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D _rigidbody2D;
	private Vector2 _moveInput;
	
	[SerializeField, Range(0f, 100f)] private float moveSpeed = 5f;
	void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		_rigidbody2D.velocity = _moveInput * moveSpeed;
	}

	void OnMove(InputValue value) {
		_moveInput = value.Get<Vector2>();
	}
}

