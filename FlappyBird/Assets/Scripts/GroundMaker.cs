using UnityEngine;
using System.Collections;

public class GroundMaker : MonoBehaviour {

    public GameObject grouds;
    private float delayTime = 1.5f;
    private float respawnTimer;
	
//    void Start() {
//        Debug.Log ("Start Coroutine");
//        StartCoroutine ("CreateGround");
//    }

	// Update is called once per frame
	void Update () {
	    if (GameManager.gameStart && !GameManager.gameOver) {
            respawnTimer += Time.deltaTime;
            if (respawnTimer > delayTime) {
                Instantiate(grouds, transform.position, transform.rotation);
                respawnTimer = 0;
            }
        }
	}

//    IEnumerator CreateGround() {
//        while (true) {
//            if (GameManager.gameStart && !GameManager.gameOver) {
//                yield return new WaitForSeconds (delayTime);
//                //respawnTimer += Time.deltaTime;
//                //if (respawnTimer > delayTime) {
//                Debug.Log("Creating ground....");
//                    Instantiate(grouds, transform.position, transform.rotation);
//                //    respawnTimer = 0;
//                //}
//            }         
//        }
//    }
}
