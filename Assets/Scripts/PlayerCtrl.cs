using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
	private Transform tr;
	private float h = 0.0f;
	private float v = 0.0f;
	public float moveSpeed = 10.0f;

	private Animator Player;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	private bool playerAttacking;
	private Vector2 lastMove;



	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
	
		Player = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement ();
        if (Input.GetKey(KeyCode.Space))
        {
            playerAttacking = true;
            //this.transform.Find("Effect_1_0").gameObject.SetActive(true);
        }
        else
        {
            playerAttacking = false;
        }
		

		Player.SetBool ("PlayerAttacking", playerAttacking);
	}

	void PlayerMovement()
	{
		playerMoving = false;
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		if (h > 0.1f || h < -0.1f) {
			myRigidbody.velocity = new Vector2 (h * moveSpeed, myRigidbody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (h, 0f);

		}
		if (v > 0.1f || v < -0.1f) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, v * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f, v);

		}
		if (h < 0.1f || h > -0.1f) {
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);

		}
		if (v < 0.1f || v > -0.1f) {
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);

		}

		Player.SetFloat ("Move X", h);
		Player.SetFloat ("Move Y", v);
		Player.SetBool ("PlayerMoving", playerMoving);
		Player.SetFloat ("LastMoveX", lastMove.x);
		Player.SetFloat ("LastMoveY", lastMove.y);
		if (Player.GetFloat ("Move X") > 0) {
			transform.localScale = new Vector2 (-1, 1);
		}
		if (Player.GetFloat ("Move X") < 0) {
			transform.localScale = new Vector2 (1, 1);
		}

		Vector2 moveDir = (Vector2.up * v) + (Vector2.right * h);

		tr.Translate (moveDir * Time.deltaTime * moveSpeed, Space.Self);
	}
}
