using UnityEngine;
using System.Collections;

public class NumberTexture : MonoBehaviour {
    public Texture2D[] lSize;
    public Texture2D[] mSize;
    public Texture2D[] sSize;

    public float windowWidth;
    public float windowHeight;
    public float windowX;
    public float windowY;
    public float numberWidth;
    public float numberHeight;

    void Start() {
        Debug.Log ("NumberTexture SIze: " + lSize.Length);
        windowWidth = Screen.width / 1.2f;
        windowHeight = Screen.height / 3.5f;
        windowX = (Screen.width - windowWidth) / 2f;            // 54
        windowY = (Screen.height - windowHeight) / 2.1f;        // 124
        numberWidth = 20;
        numberHeight = 20;
    }

    public void DrawNumber(int number) {
        string numberStr = number.ToString ();
        for (int i = 0; i < numberStr.Length; i++) {
            int index = int.Parse(numberStr[i].ToString());
            GUI.DrawTexture(new Rect(windowX + i * numberWidth, windowY, numberWidth, numberHeight), lSize[index]);
        }
    }

}
