using UnityEngine;
using System.Collections;

public class GroundMaker : MonoBehaviour {

    public GameObject grouds;
    private float delayTime = 1.5f;
    private float respawnTimer;

	// Update is called once per frame
	void Update () {
	    if (!GameManager.gameOver) {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > delayTime) {
                Instantiate(grouds, transform.position, transform.rotation);
                respawnTimer = 0;
            }
        }
	}

}
