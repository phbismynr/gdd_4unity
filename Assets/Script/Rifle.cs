using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour {
	[SerializeField]
	int _damageDealt = 50;

	[SerializeField]
	GameObject _hitEffectPrefab;

	// Use this for initialization
	void Start () {
		//Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.K)){
			//Screen.lockCursor = false;
		}
		if (Input.GetButtonDown("Fire1")){
			//Screen.lockCursor = true;
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast(mouseRay, out hitInfo)) {
				Debug.Log (hitInfo.transform.name);
				Health enemyHealth = hitInfo.transform.GetComponent<Health> ();
				if (enemyHealth != null){
					enemyHealth.Damage (_damageDealt);

					if(enemyHealth.transform.root.tag == "ObjectMusuh"){
						Vector3 hitEffectPosition = hitInfo.point;
						Quaternion hitEffectRotation = Quaternion.FromToRotation (Vector3.forward, hitInfo.normal);
						Instantiate (_hitEffectPrefab, hitEffectPosition, hitEffectRotation);
					}
				}	
			}
		}
	}
}