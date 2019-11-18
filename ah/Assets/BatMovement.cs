﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour {
	public float speed;
	public bool MoveRight;



    // Update is called once per frame
    void Update() {
		if(MoveRight) {
			transform.Translate(2 * Time.deltaTime * speed, 0,0);
			transform.localScale = new Vector2 (2,2);
		}
		else {
			transform.Translate(-2 * Time.deltaTime * speed, 0,0);
			transform.localScale = new Vector2 (-2,2);
		}
    }
	void OnCollisionEnter2D(Collision2D  col){
		if (col.gameObject.tag == "bullet"){
			
			
			Destroy(gameObject);
		

		}
	}

	void OnTriggerEnter2D(Collider2D trig) {
		if(trig.gameObject.CompareTag("Turn")){
			if(MoveRight) {
				MoveRight = false;
			}
			else {
				MoveRight = true;
			}
		}
	}

}
