using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		while(transform.childCount > 0){
			Transform child = transform.GetChild(0);
			child.parent = null;
		}
		Destroy(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
