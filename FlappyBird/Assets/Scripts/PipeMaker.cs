using UnityEngine;
using System.Collections;

public class PipeMaker : MonoBehaviour {

    public GameObject pipes;
    private float delayTime = 1.2f;
    private float respawnTimer;

	// Use this for initialization
	void Start () {
        respawnTimer = 1;
	}

	// Update is called once per frame
	void Update () {
	    if (GameManager.gameStart && !GameManager.gameOver) {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > delayTime) {
                var tolerance = Random.Range(-0.3f, 1.5f);
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + tolerance, transform.position.z);
                Instantiate(pipes, pos, transform.rotation);
                respawnTimer = 0.0f;
            }
        }
	}
}
