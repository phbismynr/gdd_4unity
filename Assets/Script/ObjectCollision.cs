using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "ObjectMusuh"){
			Debug.Log("Collide1!");
			AudioSource audio = gameObject.GetComponent<AudioSource> ();
			audio.Play();
			col.gameObject.SetActive(false);
		}
	}
}
