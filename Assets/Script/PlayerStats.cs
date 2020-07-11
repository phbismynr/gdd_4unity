using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	int _zombieKilled = 0;
	public int ZombieKilled{
		get{ return _zombieKilled; }
		set{ _zombieKilled = value;}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
