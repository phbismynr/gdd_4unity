using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	CharacterController _controller;
	Transform _player;

	[SerializeField]
	float _moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
		_player = playerObject.transform;
		_controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = _player.position - transform.position;

		direction.Normalize();
		Vector3 velocity = direction * _moveSpeed;
		_controller.Move (velocity * Time.deltaTime);
	}
}
