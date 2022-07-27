using System;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	void Start() {
		target = FindObjectOfType<PlayerController>().transform;
	}

	private void LateUpdate() {
		transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}
}

