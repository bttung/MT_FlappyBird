using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameManager.gameOver) {
            gameObject.renderer.enabled = true;
        }

        if (!gameObject.renderer.enabled) {
            return;
        }

        if (InputManager.isInputed()) {
            GameManager.ReLoadGame();
        }
	}
}
