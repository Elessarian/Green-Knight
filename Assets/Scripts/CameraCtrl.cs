using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
	private Vector3 targetPos;
	private Vector3 minBounds;
	private Vector3 maxBounds;
	private Camera theCamera;
	private float halfHeight;
	private float halfwidth;

	public GameObject FollowTarget;
	public float moveSpeed;
	public BoxCollider2D boundBox;

	// Use this for initialization
	void Start ()
	{
		minBounds = boundBox.bounds.min;
		maxBounds = boundBox.bounds.max;

		theCamera = GetComponent<Camera> ();
		halfHeight = theCamera.orthographicSize;
		halfwidth = halfHeight * Screen.width / Screen.height;
	}

	// Update is called once per frame
	void Update ()
	{
		TargetFollowLimit ();
	}

	void TargetFollowLimit()
	{
		targetPos = new Vector3 (FollowTarget.transform.position.x, FollowTarget.transform.position.y, FollowTarget.transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);

		float clampedX = Mathf.Clamp (transform.position.x, minBounds.x + halfwidth, maxBounds.x - halfwidth);
		float clampedY = Mathf.Clamp (transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
		transform.position = new Vector3 (clampedX, clampedY, transform.position.z);
	}

	public void ChangeCameraPosition(GameObject after){
		transform.position = new Vector3 (
			after.transform.position.x+1, 
			after.transform.position.y+1, 
			after.transform.position.z);
	}

	public void ChangeCameraBound(BoxCollider2D after){
		boundBox = after;
		minBounds = boundBox.bounds.min;
		maxBounds = boundBox.bounds.max;
		theCamera = GetComponent<Camera> ();
		halfHeight = theCamera.orthographicSize;
		halfwidth = halfHeight * Screen.width / Screen.height;

	}
}
