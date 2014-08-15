using UnityEngine;
using System.Collections;

public class PipeMaker : MonoBehaviour {

    public GameObject pipes;
    private int score = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating ("CreatePipe", 1f, 1.5f);
	}
	
    void OnGUI() {
        GUI.color = Color.black;
        GUILayout.Label ("Score: " + score.ToString());
        Debug.Log ("Score: " + score);
    }

	// Update is called once per frame
	void Update () {
	
	}

    void CreatePipe() {
        Instantiate (pipes);
        score++;
    }
}
