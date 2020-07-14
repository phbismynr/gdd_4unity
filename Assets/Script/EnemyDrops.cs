using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour {
[SerializeField]
	GameObject _dropItemPrefab;

	[SerializeField]
	float _chanceToDrop = 25.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onDeath(){
		if (Random.Range(0.0f, 100.0f) <= _chanceToDrop){
			Instantiate (_dropItemPrefab, transform.position, transform.rotation);
		}
	}
}
