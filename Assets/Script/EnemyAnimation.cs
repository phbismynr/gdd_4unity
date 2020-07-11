using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {
	Animation _animation;

	// Use this for initialization
	void Start () {
		_animation = GetComponentInChildren<Animation> ();

		string aniimationToPlay = "";
		switch (Random.Range(0, 3)) {
			case 0:
				aniimationToPlay = "Move1";
			  	break;
			case 1:	
			   	aniimationToPlay = "Move2";
				break;
			case 2:	
			    aniimationToPlay = "Move3";
				break;
			default:
			  	aniimationToPlay = "Move1";
			  	break;
		}

		_animation["Move1"].wrapMode = WrapMode.Loop;
		_animation.Play(aniimationToPlay);
		_animation[aniimationToPlay].normalizedTime = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
