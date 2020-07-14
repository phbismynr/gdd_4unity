using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuGui : MonoBehaviour {
[SerializeField]
	Texture2D _mainMenuBg;

	[SerializeField]
	Texture2D _title;

	[SerializeField]
	Texture2D _newGameButton;

	[SerializeField]
	Texture2D _optionButton;

	[SerializeField]
	Texture2D _quiteButton;

	[SerializeField]
	GUISkin _guiSkin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.skin = _guiSkin;

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), _mainMenuBg);
		GUI.DrawTexture (new Rect (Screen.width - _title.width - 20, 20, _title.width, _title.height), _title);
		if (GUI.Button(new Rect(20, 150, 270, _newGameButton.height), _newGameButton) && !GameOptions.IsOpen){
			SceneManager.LoadScene("SurvivalGame");
		}
		if (GUI.Button(new Rect(20, 150 + 45 + 10, 270, _optionButton.height), _optionButton) && !GameOptions.IsOpen){
			GameOptions.Open ();

		}
		if(GUI.Button(new Rect(20, 150 + (2 * (50 + 10)), 270, _quiteButton.height), _quiteButton) && !GameOptions.IsOpen){
			Application.Quit ();
		}
	}
}
