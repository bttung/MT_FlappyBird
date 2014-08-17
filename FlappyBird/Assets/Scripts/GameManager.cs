using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static bool gameStart;
    public static bool gameOver;
    public static int score;
    public static bool medal;

	// Use this for initialization
	void Start () {
        Init ();   
	}

    public static void Init() {
        gameStart = false;
        gameOver = false;
        score = 0;
        medal = false;
    }
}
