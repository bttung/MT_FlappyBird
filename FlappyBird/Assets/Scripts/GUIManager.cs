using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public Texture2D scoreBoard;
    public Texture2D gameOver;
    public Texture2D goldGray;
    public Texture2D goldGold;
    public Texture2D play;
    public GameObject numbTxt;
    public NumberTexture texture;

    void Start() {
        numbTxt = GameObject.Find ("Numbers");
    }

    void OnGUI() {
        var windowWidth = Screen.width / 1.2f;
        var windowHeight = Screen.height / 3.5f;
        var windowX = (Screen.width - windowWidth) / 2f;
        var windowY = (Screen.height - windowHeight) / 2.1f;

        if (GameManager.gameStart && !GameManager.gameOver) {
            GUI.Label (new Rect(Screen.width / 2f, Screen.height / 4f, 100, 20), GameManager.score.ToString());
        }

        if (GameManager.gameOver) {
            GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f, windowWidth / 3f, windowHeight / 3f), gameOver);
            GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f + 100f, windowWidth / 3f, windowHeight / 3f), scoreBoard);
            //GUI.Label (new Rect(windowX + 350, windowY / 2f + 70f, windowWidth / 3f, windowHeight / 3f), "Score: " + GameManager.score.ToString());
            //NumberTexture.DrawNumber(GameManager.score);
            string scoreStr = GameManager.score.ToString();
            for (int i = 0; i < scoreStr.Length; i++) {
                GUI.DrawTexture(new Rect(windowX + 200 + i * 10, windowY / 2f + 100f, windowWidth / 3f, windowHeight / 3f), texture.lSize[(int) scoreStr[i]]);
            }

            Debug.Log("...GameOver");
            GUI.Label (new Rect(windowX + 350, windowY / 2f + 100f, windowWidth / 3f, windowHeight / 3f), "HighScore: " + PlayerPrefs.GetInt("highScore").ToString());
            Debug.Log("Drew High Score" + PlayerPrefs.GetInt("highScore"));

            if (GameManager.medal) {
                GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f + 150f, windowWidth / 3f, windowHeight / 3f), 
                                goldGold);
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
