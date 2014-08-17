using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public Texture2D scoreBoard;
    public Texture2D gameOver;
    public Texture2D goldGray;
    public Texture2D goldGold;
    public Texture2D play;

    public GameObject numbTxt;
    public NumberTexture numberTxt;
    public Texture2D tmpTexture;

    void Start() {
        numbTxt = GameObject.Find ("Numbers");
        numberTxt = numbTxt.GetComponent<NumberTexture> ();
    }
    
    void OnGUI() {
        float windowWidth = Screen.width / 1.2f;
        float windowHeight = Screen.height / 3.5f;
        float windowX = (Screen.width - windowWidth) / 2f;            // 54
        float windowY = (Screen.height - windowHeight) / 2.1f;        // 124
        Debug.Log ("windowX " + windowX + " windowY " + windowY);

        if (GameManager.gameStart && !GameManager.gameOver) {
            numberTxt.DrawNumber(GameManager.score, new Vector2(windowX, windowY), "Big");
        }

        if (GameManager.gameOver) {
            // Draw Game Result Box
            GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f, windowWidth / 3f, windowHeight / 3f), gameOver);
            GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f + 100f, windowWidth / 3f, windowHeight / 3f), scoreBoard);

            //  Draw Score
            numberTxt.DrawNumber(GameManager.score, new Vector2(windowX, windowY), "Big");
            numberTxt.DrawNumber(PlayerPrefs.GetInt("highScore"), new Vector2(windowX, windowY + 30f), "Big");

            // Draw Medal
            if (GameManager.medal) {
                GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f + 150f, windowWidth / 3f, windowHeight / 3f), goldGold);
            } else {
                GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f + 170f, windowWidth / 5f, windowHeight / 5f), goldGray);
            }

            if (GUI.Button(new Rect(windowX + 200, windowY / 2f + 250f, windowWidth / 5f, windowHeight / 3f), play)) {
                GameManager.Init();
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
