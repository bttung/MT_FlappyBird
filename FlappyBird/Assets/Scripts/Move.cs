using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
    static float velocity = -2.0f;

	// Update is called once per frame
	void Update () {
	    if (!(GameManager.gameStop || GameManager.gameOver)) {
            transform.Translate(Time.deltaTime * velocity, 0, 0);
        }
	}
}
