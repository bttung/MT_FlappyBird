using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public AudioClip hit;
    public static int playTime; 

	// Use this for initialization
	void Start () {
        playTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (playTime == 1) {
            AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);
            playTime++;
        }
    }

    public static void SoundTrigger() {
        playTime++;
    }
}
