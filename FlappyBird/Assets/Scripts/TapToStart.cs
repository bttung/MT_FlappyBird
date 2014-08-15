using UnityEngine;
using System.Collections;

public class TapToStart : MonoBehaviour {

    GameObject tap;
    GameObject ready;

	// Use this for initialization
	void Start () {
        tap = GameObject.Find ("Tapper");
        ready = GameObject.Find ("Ready");
        tap.gameObject.renderer.enabled = true;
        ready.gameObject.renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.gameStart) {
            tap.gameObject.renderer.enabled = false;
            ready.gameObject.renderer.enabled = false;
        }
    }
}
