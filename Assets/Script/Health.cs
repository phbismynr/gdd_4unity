using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	[SerializeField]
	int _maximumHealth = 100;
	int _currentHealth = 0;

	// Use this for initialization
	void Start () {
		_currentHealth = _maximumHealth;
		// GetComponent<Health>().Damage(100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void  Damage(int damageValue){
		_currentHealth -= damageValue;

		if(_currentHealth <= 0){
			// Destroy (gameObject);
			Animation anim = GetComponentInChildren<Animation> ();
			anim.Stop();

			// Destroy(GetComponent<PlayerMovement>());
			// Destroy(GetComponent<PlayerAnimation> ());

			Destroy (GetComponent<EnemyMovement> ());
			Destroy (GetComponent<CharacterController> ());

			Regdoll r = GetComponent<Regdoll> ();
			if(r != null){
				r.onDeath();
			}
		}
	}
}
