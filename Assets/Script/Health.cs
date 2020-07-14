using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
[SerializeField]
	int _maximumHealth = 100;
	int _currentHealth = 0;

	[SerializeField]
	AudioClip[] _hitSound;

	[SerializeField]
	AudioClip _deathSound;

	Renderer _renderer;

	public bool isDeath(){
		return _currentHealth <= 0;
	}

	PlayerStats _playerStats;

	// Use this for initialization
	void Start () {
		_renderer = GetComponentInChildren<Renderer> ();
		_currentHealth = _maximumHealth;

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		_playerStats = player.GetComponent<PlayerStats> ();
			
	}
	
	// Update is called once per frame
	void Update () {
		if (isDeath() && !_renderer.isVisible){
			Destroy (gameObject);
		}

		
	}

	public void Damage(int damageValue){
		_currentHealth -= damageValue;
		if (_currentHealth < 0){
			_currentHealth = 0;
		} else {
			if (_hitSound != null && _hitSound.Length > 0){
				AudioSource audio = GetComponent<AudioSource> ();
				AudioClip soundToUse = _hitSound [Random.Range (0, _hitSound.Length)];
				audio.clip = soundToUse;
				audio.Play ();
			}
		}

		if (_currentHealth == 0){
			if (_hitSound != null){
				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = _deathSound;
				audio.Play ();
			}

			Animation anim = GetComponentInChildren<Animation> ();
			anim.Stop ();

			_playerStats.ZombieKilled++;

			EnemyDrops ed = GetComponent<EnemyDrops> ();
			ed.onDeath();

			EnemySpawnManager.onEnemyDeath ();
			Destroy (GetComponent<EnemyMovement> ());
			Destroy (GetComponent<EnemyAttack> ());
			Destroy (GetComponent<CharacterController> ());
			Destroy (gameObject, 8.0f);

			Regdoll r = GetComponent<Regdoll> ();
			if (r != null){
				r.onDeath ();
			}
		}
	}
}