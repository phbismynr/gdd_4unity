using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regdoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DisableRegdoll();
		
	}

	void DisableRegdoll(){
		Rigidbody[] allRigidbodies = GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody r in allRigidbodies) {
			r.isKinematic = true;
		}
	}

	void EnableRegdoll(){
		Rigidbody[] allRigidbodies = GetComponentsInChildren<Rigidbody> ();
		foreach (Rigidbody r in allRigidbodies) {
			r.isKinematic = false;
		}
	}

	public void onDeath(){
		EnableRegdoll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
