using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour {
    public Texture2D baktexture;
    public Texture2D collideTexture;
    public Vector3 collidePosition;

    private float fadeAlpha = 0.0f;
    private bool isFading;

    void Start() {
        isFading = false;
    }

    public void OnGUI () {
        if (!isFading) {
            return;
        }
        
        // Update Color and Texture
        GUI.color = new Color (0, 0, 0, fadeAlpha);
        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), baktexture);
//        if (collidePosition != null) {
//            GUI.DrawTexture (new Rect (collidePosition.x, collidePosition.y, 20, 20), collideTexture);
//        }
    }

    public void MakeFlashLight(float interval) {
        StartCoroutine (MakeFadeEffect (interval));
    }

    private IEnumerator MakeFadeEffect (float interval) {
        isFading = true;
        float time = 0;

        // Darker Step by Step
        time = 0;
        while (time <= interval) {
            fadeAlpha = Mathf.Lerp (0f, 0.3f, time / interval);
            time += Time.deltaTime;
            yield return 0;
        }
        
        isFading = false;
    }

}