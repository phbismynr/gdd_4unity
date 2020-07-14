using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : MonoBehaviour {

	[SerializeField]
	GameObject _missilePrefab;

	[SerializeField]
	Transform _muzzle;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.K)){
			Cursor.lockState = CursorLockMode.None;
		}

		if(Input.GetButtonDown("Fire1")){
			Cursor.lockState = CursorLockMode.None;
			Ray mouseRay = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
			RaycastHit hitInfo;

			Vector3 direction;
			if (Physics.Raycast(mouseRay, out hitInfo) && 
				(Camera.main.WorldToScreenPoint(hitInfo.point).z >= Camera.main.WorldToScreenPoint(_muzzle.position).z)){
				direction = hitInfo.point - _muzzle.position;
				direction.Normalize ();
			} else {
				direction = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 50)) - _muzzle.position;
				direction.Normalize ();
			}
			GameObject m = (Instantiate (_missilePrefab, _muzzle.position, _muzzle.rotation)) as GameObject;
			m.transform.forward = direction;
		}
		
	}
}
