using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
    private float upForce = 2.7f;
    private float rotz = 0f;
    private float some = 5f;
    private float downVel = -7.2f;
    private Vector3 birdPos;
    private Vector3 tmpPos;
    
    // Use this for initialization
    void Start () {
        rotz = 0;
        birdPos = transform.position;
        tmpPos = new Vector3 (birdPos.x, birdPos.y, birdPos.z);
    }
    
    // Update is called once per frame
    void Update () {
        if (!GameManager.gameStart || GameManager.gameOver) {
            rigidbody2D.gravityScale = 0.0f;
        } else {
            rigidbody2D.gravityScale = 0.5f;
        }

        // Check if the bird is able to receive user input
        if (InputManager.isInputReceivable ()) {
            // Check if user inputed valid key
            if (InputManager.isInputed()) {
                rigidbody2D.velocity = new Vector2 (0f, upForce);
            }
        }

        if (!GameManager.gameStart) {
            rotz = Mathf.Lerp (rotz, 25f * Mathf.Sin(Time.deltaTime), Time.deltaTime * 6);
            var rot = Quaternion.Euler (0, 0, rotz);
            transform.rotation = rot;
        }

        if (!GameManager.gameStart || GameManager.gameOver) {
            transform.position = tmpPos;
        }

        // Limit the velocity of fall down
        if (rigidbody2D.velocity.y < downVel) {
            Vector3 tempVel = new Vector3 (0f, downVel, 0f);
            rigidbody2D.velocity = tempVel;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ScoreArea") {
            GameManager.score++;
            Destroy (other.gameObject);
        } else if (other.gameObject.tag == "Pipe") {
            SoundManager.SoundTrigger();
            GameManager.gameStop = true;
        } else if (other.gameObject.tag == "Ground") {
            SoundManager.SoundTrigger();
            GameManager.gameOver = true;
            gameObject.collider2D.isTrigger = false;
            tmpPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        }

        if (GameManager.gameOver) {
            if (GameManager.score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore", GameManager.score);
                GameManager.medal = true;
            }
            GameManager.gameOver = true;
        }
    }
}
