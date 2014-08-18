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

        if (GameManager.gameStart && !GameManager.gameOver) {
            numberTxt.DrawNumber(GameManager.score, new Vector2(315, 120), "Big");
        }

        if (GameManager.gameOver) {
            // Draw Game Result Box
            DrawTexture(new Vector2(255, 150), gameOver, 0.7f);
            DrawTexture(new Vector2(235, 200), scoreBoard, 0.8f);

            // Draw Score
            numberTxt.DrawNumber(GameManager.score, new Vector2(380, 230), "Medium");
            numberTxt.DrawNumber(PlayerPrefs.GetInt("highScore"), new Vector2(380, 265), "Medium");

            // Draw Medal
            if (GameManager.medal) {
                DrawTexture(new Vector2(257, 235), goldGold, 0.8f);
            } else {
                DrawTexture(new Vector2(257, 235), goldGray, 0.8f);
            }

            if (GUI.Button(new Rect(250, 330, play.width, play.height), play)) {
                GameManager.Init();
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    void DrawTexture(Vector2 pos, Texture2D texture, float scale) {
        GUI.DrawTexture(new Rect(pos.x, pos.y, texture.width * scale, texture.height * scale), texture);
    }
}
