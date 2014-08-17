using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (!GameManager.gameOver) {
            transform.Translate(-Time.deltaTime * 2.0f, 0, 0);
        }
	}
}
