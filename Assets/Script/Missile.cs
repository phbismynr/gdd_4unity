using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
	[SerializeField]
	float _speed = 10.0f;

	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponentInChildren<Rigidbody> ();
		rigidbody.AddRelativeForce (new Vector3 (0, 0, _speed), ForceMode.VelocityChange);
		
	}

	void OnCollisionEnter(Collision c){
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
