using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	int _maximumHealth = 100;

	[SerializeField]
	Texture2D _crosshair;

	[SerializeField]
	Texture2D _gameOverImage;

	public int _currentHealt = 0;

	Renderer _renderer;
	PlayerStats _playerStats;

	[SerializeField]
	Texture2D _winImage;

	public string health(){
		return _currentHealt + " / " + _maximumHealth;
	}

	public bool isDeath(){
		return _currentHealt <= 0;
	}

	// Use this for initialization
	void Start () {
		_renderer = GetComponentInChildren<Renderer>();
		_currentHealt = _maximumHealth;
		_crosshair = new Texture2D (2,2);
		_playerStats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDeath() && !_renderer.isVisible){
			Destroy (gameObject);
		}
	}

	public void Damage(int damageValue){
		_currentHealt -= damageValue;
		if(_currentHealt < 0){
			_currentHealt = 0;
		}

		if(_currentHealt == 0){
			Animation anim = GetComponentInChildren<Animation>();
			anim.Stop();
			Destroy(GetComponent<PlayerMovement>());
			Destroy(GetComponent<PlayerAnimation>());
			Destroy(GetComponentInChildren<LookX>());
			Destroy(GetComponentInChildren<Rifle>());

			Regdoll r = GetComponent<Regdoll>();
			if(r != null){
				r.onDeath ();
			}
		}
	}


	void OnGUI(){
		if(isDeath() && !_renderer.isVisible){
			float x = (Screen.width - _gameOverImage.width) / 2;
			float y = (Screen.height - _gameOverImage.height) / 2;
			GUI.DrawTexture(new Rect(x, y, _gameOverImage.width, _gameOverImage.height), _gameOverImage);
			GUI.Label(new Rect(x+100, y+280, 100, 100), "Zombie Killed: "+ _playerStats.ZombieKilled);
		}else if(GameManager.HasPlayerWon){
			float x = (Screen.width - _winImage.width)/2;
			float y = (Screen.height - _winImage.height)/2;
			GUI.DrawTexture(new Rect(x, y, _winImage.width, _winImage.height), _winImage);

		}else{
			GUI.Label(new Rect(5, 5, 100, 100), "Health: "+ health() + " | Zombie Killed: "+ _playerStats.ZombieKilled);
			float x = (Screen.width - _crosshair.width) / 2;
			float y = (Screen.height - _crosshair.height) / 2;
			GUI.DrawTexture(new Rect(x, y, _crosshair.width, _crosshair.height), _crosshair);
		}
	}
}
