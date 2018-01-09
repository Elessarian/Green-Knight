using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {
	private Transform Entrance;
	private GameObject mainCamera;

	public GameObject Exit;
	public BoxCollider2D ExitBound;

	// Use this for initialization
	void Start () {
		Entrance = GetComponent<Transform> ();
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Vector3 dir = (other.gameObject.transform.position - gameObject.transform.position).normalized;
		if (other.gameObject.name == "Player") {
			if (dir.x < 0) {
				other.transform.position = new Vector3 (
					Exit.transform.position.x - 1, 
					other.transform.position.y,
					other.transform.position.z);
			}
			if (dir.x > 0) {
				other.transform.position = new Vector3 (
					Exit.transform.position.x + 1, 
					other.transform.position.y,
					other.transform.position.z);
			}

			mainCamera.SetActive (false);
			mainCamera.GetComponent<CameraCtrl>().ChangeCameraBound (ExitBound);
			mainCamera.GetComponent<CameraCtrl>().ChangeCameraPosition (Exit);
			mainCamera.SetActive (true);
		}
	}
}
