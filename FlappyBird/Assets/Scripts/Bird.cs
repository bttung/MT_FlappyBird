﻿using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    public Vector2 jumpForce = new Vector2(0, 300);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.gameStart) {
            rigidbody2D.gravityScale = 0f;
            //Debug.Log ("Bird has no gravity");
        } else {
            rigidbody2D.gravityScale = 0.5f;
            //Debug.Log ("Bird is going to fall");
        }


	    // Jump
        if (Input.GetKeyUp (KeyCode.Space)) {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce);
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0) {
            Die();
        }
	}

    void OnCollisionEnter2D(Collision2D other) {
          Die ();
    }

    void Die() {
        Debug.Log ("Player died. Reload the game now ...");
        Application.LoadLevel (Application.loadedLevel);
    }
}
