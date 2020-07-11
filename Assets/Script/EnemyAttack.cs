using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	[SerializeField]
	float _attactDelay = 1.0f;

	[SerializeField]
	int _damageDeath = 5;

	float _nextTimeAttactIsAllowed = -1.0f;

	void OnTriggerStay(Collider other){
		if(other.tag == "Player" && Time.time >= _nextTimeAttactIsAllowed){
			PlayerHealth _playerHealth = other.GetComponent<PlayerHealth>();
			if(_playerHealth._currentHealt > 0 ){
				_playerHealth.Damage (_damageDeath);
				_nextTimeAttactIsAllowed = Time.time + _attactDelay;
			}else{
				Animation anim = GetComponentInChildren<Animation>();
				anim.Stop();
				Destroy(GetComponentInParent<CharacterController>());
				Destroy(GetComponentInParent<EnemyMovement>());
				Destroy(GetComponentInParent<EnemyAnimation>());
				Destroy(GetComponentInParent<EnemyAttack>());
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
