using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour {
[SerializeField]
	GUISkin _guiSkin;

	[SerializeField]
	Texture2D _tittle;

	[SerializeField]
	Texture2D _ok;

	[SerializeField]
	Texture2D _tittleDifficulty;

	[SerializeField]
	Texture2D[] _difficulties;

	[SerializeField]
	Texture2D _titleSound;

	static float _soundVolume = 1.0f;


	static int _selectedDifficulty = 0;
	static bool _isOpen = false;

	static public bool IsOpen {
		get{ return _isOpen; }
	}

	static public void Open(){
		_isOpen = true;
	}

	// Use this for initialization
	void Start () {
		_selectedDifficulty = PlayerPrefs.GetInt ("Difficulty", 1);
		_soundVolume = PlayerPrefs.GetFloat ("SoundVolume", 1.0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		if (!_isOpen){
			return;
		}
		GUI.skin = _guiSkin;
		GUI.Box (new Rect (15, 15, Screen.width - 30, Screen.height - 30), "");
		GUI.DrawTexture (new Rect (20, 20, _tittle.width, _tittle.height), _tittle);
		GUI.DrawTexture (new Rect (50, 150, _tittleDifficulty.width, _tittleDifficulty.height), _tittleDifficulty);
		_selectedDifficulty = GUI.SelectionGrid (new Rect (100, 190, 200, 400), _selectedDifficulty, _difficulties, 1, "CheckboxStyle");
		
		PlayerPrefs.SetInt ("Difficulty", _selectedDifficulty);

		GUI.DrawTexture(new Rect(280, 120, _titleSound.width, _titleSound.height), _titleSound);
		_soundVolume = GUI.HorizontalSlider(new Rect(280, 180, Screen.width - 500, 20), _soundVolume, 0.0f, 1.0f);

		PlayerPrefs.SetFloat("SoundVolume", _soundVolume);

		if(GUI.Button(new Rect(Screen.width - 30 - _ok.width - 10, Screen.height - 30 - _ok.height - 10, _ok.width, _ok.height), _ok)){
			Close ();
		}
	}

	void Close(){
		_isOpen = false;
	}
}
