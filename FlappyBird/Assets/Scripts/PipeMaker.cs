using UnityEngine;
using System.Collections;

public class PipeMaker : MonoBehaviour {

    public bool up = false;
    public bool down = true;

    public GameObject pipes;
    public float delayTime = 1.5f;
    private float respawnTimer;

	// Use this for initialization
	void Start () {
        respawnTimer = 1;
	}

	// Update is called once per frame
	void Update () {
	    if (GameManager.gameStart && !GameManager.gameOver) {
            if (up) {
                respawnTimer += Time.deltaTime;
                if (respawnTimer > delayTime) {
                    var tolerance = Random.Range(0f, 3f);
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y + tolerance, transform.position.z);
                    var newObj = Instantiate(pipes, pos, transform.rotation);
                    respawnTimer = 0.0f;
                }
            }
            if (down) {
                respawnTimer += Time.deltaTime;
                if (respawnTimer > delayTime) {
                    var tolerance = Random.Range(0f, 3f);
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y + tolerance, transform.position.z);
                    var newObj = Instantiate(pipes, pos, transform.rotation);
                    respawnTimer = 0.0f;
                }
            }
        }
	}
}
