using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_HIt : MonoBehaviour {
	public int monsterHeart;
	public int monsterAtt;
	// Use this for initialization
	void Start () {
		monsterHeart = 1;
		monsterAtt = 1;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Weapon") {
			monsterHeart -= 1;
			if (monsterHeart == 0) {
				Destroy (this.transform.parent.gameObject);
			}
		}
	}
}
