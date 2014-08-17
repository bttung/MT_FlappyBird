using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
    private float upForce = 2.7f;
    private float rotz = 0f;
    private float some = 5f;
    private float downVel = -7.2f;
    private Vector3 birdPos;
    public AudioClip hit;
    
    // Use this for initialization
    void Start () {
        rotz = 0;
        birdPos = transform.position;
    }
    
    // Update is called once per frame
    void Update () {
        if (!GameManager.gameStart || GameManager.gameOver) {
            rigidbody2D.gravityScale = 0.0f;
        } else {
            rigidbody2D.gravityScale = 0.5f;
        }

        var pos = new Vector3 (birdPos.x,transform.position.y, transform.position.z);
        transform.position = pos;

        if ((Input.GetKeyDown (KeyCode.Space)||Input.GetMouseButtonDown(0)) &&
            !GameManager.gameOver&&GameManager.gameStart) {
            rigidbody2D.velocity = new Vector2 (0f, upForce);
        }

        if (!GameManager.gameStart || GameManager.gameOver) {
            Vector3 temp = new Vector3(transform.position.x, 1.0f,transform.position.z);
            transform.position = temp;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ScoreArea") {
            GameManager.score++;
            Destroy (other.gameObject);
        } else if (other.gameObject.tag == "Pipe") {
            gameObject.collider2D.isTrigger = false;
            AudioSource.PlayClipAtPoint(hit, Camera.main.transform.position);
            if (GameManager.score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore", GameManager.score);
                GameManager.medal = true;
            }
            GameManager.gameOver = true;
        }
    }
}
