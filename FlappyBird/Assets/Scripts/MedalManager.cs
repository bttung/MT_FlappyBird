using UnityEngine;
using System.Collections;

public class MedalManager : MonoBehaviour {
    public Texture2D[] medal;

    public Texture2D getMedal(int score) {
        if (score >= 40) {
            // Gold
            return medal[3];
        }
        if (score >= 30) {
            // Silver
            return medal[2];
        }
        if (score >= 20) {
            // Bronze
            return medal[1];
        }
        if (score >= 10) {
            // Normal
            return medal[0];
        }
        return null;
    }

}
