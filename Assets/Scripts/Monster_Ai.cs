using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Ai : MonoBehaviour {

	public float movePower = 1f;
    public float tracePower;
	Vector3 movement;
	Animator animator;
	float movementFlagX;
	float movementFlagY;
	SpriteRenderer renderer;
	GameObject playerTrace;
	bool isTrace;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponentInChildren<Animator> ();
		renderer = gameObject.GetComponentInChildren<SpriteRenderer> ();
		isTrace = false;
		StartCoroutine ("ChangeMovement");
	}
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
		Move ();
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			playerTrace = other.gameObject;
			StopCoroutine ("ChangeMovement");
			movePower = tracePower;
			isTrace = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			movePower = 1f;
			isTrace = false;
			StartCoroutine ("ChangeMovement");
		}
	}

	void Move(){
		if (isTrace == true) {
			Vector2 playerPos = playerTrace.transform.position;
			Vector2 thisPos = this.transform.position;
			movementFlagX = playerPos.x - thisPos.x;
			movementFlagY = playerPos.y - thisPos.y;
		}
		float moveX = movementFlagX * movePower * Time.deltaTime;
		if (moveX > 0) {
			renderer.flipX = false;
		} 
		else {
			renderer.flipX = true;
		}
		float moveY = movementFlagY * movePower * Time.deltaTime;
		this.gameObject.transform.Translate (moveX, moveY, 0);
	}
	IEnumerator ChangeMovement(){
		movementFlagX = Random.Range (-10, 10)*0.1f;
		movementFlagY = Random.Range (-10, 10)*0.1f;
		yield return new WaitForSeconds (1f);
		StartCoroutine ("ChangeMovement");
	}
}
