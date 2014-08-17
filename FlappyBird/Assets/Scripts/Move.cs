using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Vector2 velocity = new Vector2(-4, 0);
    public float range = 4;
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.gameStart) {
            return;
        }
	    if (GameManager.gameStart && !GameManager.gameOver) {
            transform.Translate(-Time.deltaTime * 2.0f, 0, 0);
        }
	}
}
