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
        Debug.Log ("Number size: " + numberTxt.lSize.Length);
//        GUI.Label (new Rect(200, 300, 100, 20), "AAAAAAAAAAAA");
    }

//    void DrawNumber(int number) {
//        string numberStr = number.ToString ();
//        for (int i = 0; i < number.ToString().Length; i++) {
//            int index = int.Parse(numberStr[i].ToString());
//            tmpTexture = numberTxt.lSize[index];
//            GUI.DrawTexture(new Rect(250 + i * 10, 200, 20, 20), tmpTexture);
//            Debug.Log("drew...");
//        }
//    }
    
    void OnGUI() {
        float windowWidth = Screen.width / 1.2f;
        float windowHeight = Screen.height / 3.5f;
        float windowX = (Screen.width - windowWidth) / 2f;            // 54
        float windowY = (Screen.height - windowHeight) / 2.1f;        // 124
        Debug.Log ("windowX " + windowX + " windowY " + windowY);

        if (GameManager.gameStart && !GameManager.gameOver) {
            GUI.Label (new Rect(Screen.width / 2f, Screen.height / 4f, 100, 20), GameManager.score.ToString());
        }

        if (GameManager.gameOver) {
            GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f, windowWidth / 3f, windowHeight / 3f), gameOver);
            GUI.DrawTexture(new Rect(windowX + 200, windowY / 2f + 100f, windowWidth / 3f, windowHeight / 3f), scoreBoard);
            //GUI.Label (new Rect(windowX + 350, windowY / 2f + 70f, windowWidth / 3f, windowHeight / 3f), "Score: " + GameManager.score.ToString());
            //NumberTexture.DrawNumber(GameManager.score);
            Debug.Log("...GameOver");

            string scoreStr = GameManager.score.ToString();
            Debug.Log ("Score: " + scoreStr);

            numberTxt.DrawNumber(GameManager.score);
//            DrawNumber(GameManager.score);
//                        for (int i = 0; i < scoreStr.Length; i++) {
//                int index = int.Parse(scoreStr[i].ToString());
//                tmpTexture = numberTxt.lSize[index];
//                GUI.DrawTexture(new Rect(windowX + 200 + i * 10, windowY / 2f + 100f, 10, 10), tmpTexture);
//            }

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
