using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool gameStart = false;
    public static bool gameOver = false;
    public static int score = 0;

	// Use this for initialization
	void Start () {
        Init ();   
	}

    void Init() {
        gameStart = false;
        gameOver = false;
        score = 0;
    }

    void Update() {
        if (!gameStart) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log ("Start Game now...");
                gameStart = true;
            }
        }
    }
}
