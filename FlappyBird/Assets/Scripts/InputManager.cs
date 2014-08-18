using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public static bool isInputReceivable() {
        if (!GameManager.gameStart) {
            return false;
        }
        
        if (GameManager.gameStop || GameManager.gameOver) {
            return false;
        }
        
        return true;
    }
    
    public static bool isInputed() {
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            return true;
        }
        return false;
    }

}
