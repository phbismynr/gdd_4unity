using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	[SerializeField]
	float _attackDelay = 1.0f;

	[SerializeField]
	int _damageDealt = 5;

	float _nextTimeAttackIsAllowed = -1.0f;

	[SerializeField]
	GameObject _hitEffectPrefab;

	void OnTriggerStay(Collider other){
		if (other.tag== "Player" && Time.time >= _nextTimeAttackIsAllowed){
			if (PlayerHealth._currentHealth > 0){
				PlayerHealth _playerHealth = other.GetComponent<PlayerHealth> ();
				_playerHealth.Damage (_damageDealt);
				_nextTimeAttackIsAllowed = Time.time + _attackDelay;

				Vector3 hitDirection = (transform.root.position = other.transform.position).normalized;
				Vector3 hitEffectPosition = other.transform.position + (hitDirection * 0.01f) + (Vector3.up * 0.5f);
				Quaternion hitEffectRotation = Quaternion.FromToRotation(Vector3.forward, hitDirection);
				if(_hitEffectPrefab != null){
					Instantiate(_hitEffectPrefab, hitEffectPosition, hitEffectRotation);
				}

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
