using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public Texture2D scoreBoard;
    public Texture2D gameOver;
    public Texture2D goldGray;
    public Texture2D goldGold;
    public Texture2D play;

    public GameObject backGround;
    public GameObject numberDrawer;
    public NumberTexture numberTxt;
    public Texture2D tmpTexture;
    private float scale;

    private GameObject medalManager;
    private MedalManager medalComp;
    private Texture2D medalTexture;

    void Start() {
        numberDrawer = GameObject.Find ("Numbers");
        numberTxt = numberDrawer.GetComponent<NumberTexture> ();
        scale = 0.75f;

        medalManager = GameObject.Find ("Medal");
        medalComp = medalManager.GetComponent<MedalManager> ();
    }
    
    void OnGUI() {
        if (GameManager.gameStart && !GameManager.gameOver) {
            numberTxt.DrawNumber(GameManager.score, new Vector2(Screen.width / 2 - 10, Screen.height / 2 - 150), "Big");
        }

        if (GameManager.gameOver) {
            // Draw Game Result Box
            DrawTexture(new Vector2(Screen.width / 2 - gameOver.width * scale / 2, Screen.height / 2 - 100), gameOver, scale);
            DrawTexture(new Vector2(Screen.width / 2 - scoreBoard.width * scale / 2, Screen.height / 2 - 50), scoreBoard, scale);

            // Draw Score
            numberTxt.DrawNumber(GameManager.score, new Vector2(Screen.width / 2 + 48, Screen.height / 2 - 20), "Medium");
            numberTxt.DrawNumber(PlayerPrefs.GetInt("highScore"), new Vector2(Screen.width / 2 + 48, Screen.height / 2 + 15), "Medium");

            // Get Medal
            medalTexture = medalComp.getMedal(GameManager.score);
            // Draw Medal
            if (medalTexture != null) {
                DrawTexture(new Vector2(Screen.width / 2 - 67, Screen.height / 2 - 18), medalTexture, 0.8f);
            }

        }
    }

    void DrawTexture(Vector2 pos, Texture2D texture, float scale) {
        GUI.DrawTexture(new Rect(pos.x, pos.y, texture.width * scale, texture.height * scale), texture);
    }
}
