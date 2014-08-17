using UnityEngine;
using System.Collections;

public class NumberTexture : MonoBehaviour {
    public Texture2D[] lSize;
    public Texture2D[] mSize;
    public Texture2D[] sSize;
    public Texture2D[] tmpSize;

    public float numberWidth;
    public float numberHeight;

    void SetSize(string size) {
        if (size == "Big") {
            tmpSize = lSize;
            numberWidth = 20;
            numberHeight = 20;
        } else if (size == "Small") {
            tmpSize = sSize;
            numberWidth = 15;
            numberHeight = 15;
        } else {
            tmpSize = mSize;
            numberWidth = 10;
            numberHeight = 10;
        }
    }

    public void DrawNumber(int number, Vector2 pos, string size) {
        SetSize (size);
        string numberStr = number.ToString ();
        for (int i = 0; i < numberStr.Length; i++) {
            int index = int.Parse(numberStr[i].ToString());
            GUI.DrawTexture(new Rect(pos.x + i * numberWidth, pos.y, numberWidth, numberHeight), tmpSize[index]);
        }
    }

}
