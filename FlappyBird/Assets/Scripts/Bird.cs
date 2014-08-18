using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
    private float upVel = 2.4f;
    private float downVel = -3.6f;
    private float rotz = 0f;
    private Vector3 tmpPos;
    private int collidedTime;

    GameObject camera;
    Camera cameraComp;
    GameObject fadeManager;
    FadeManager fadeComp;
    
    // Use this for initialization
    void Start () {
        rotz = 0;
        tmpPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        collidedTime = 0;

        // Get Camera Component
        camera = GameObject.Find ("MainCamera");
        cameraComp = camera.GetComponent<Camera> ();

        // Get FadeManager Component
        fadeManager = GameObject.Find ("FadeManager");
        fadeComp = fadeManager.GetComponent<FadeManager> ();
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
                rigidbody2D.velocity = new Vector2 (0f, upVel);
            }
        }

        if (GameManager.gameStart && !GameManager.gameOver) {
            Quaternion rot;
            if (rigidbody2D.velocity.y > 0) {
                // Flying up
                rotz = Mathf.Lerp (rotz, 30, Time.deltaTime * 5);
            } else {
                // Flying down
                rotz = Mathf.Lerp (rotz, -90, Time.deltaTime);
            }
            rot = Quaternion.Euler (0, 0, rotz);
            transform.rotation = rot;
        }

        if (!GameManager.gameStart) {
            rotz = Mathf.Lerp (rotz, 25f * Mathf.Sin(Time.deltaTime), Time.deltaTime * 6);
            var rot = Quaternion.Euler (0, 0, rotz);
            transform.rotation = rot;
        }

        if (!GameManager.gameStart || GameManager.gameOver) {
            transform.position = tmpPos;
        }

        // Limit the velocity of fly up
        if (rigidbody2D.velocity.y > upVel) { 
            Vector3 tempVel = new Vector3 (0f, upVel, 0f);
            rigidbody2D.velocity = tempVel;
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
            SendCollidePosition();
            SoundManager.SoundTrigger();
            GameManager.gameStop = true;
        } else if (other.gameObject.tag == "Ground") {
            SendCollidePosition();
            SoundManager.SoundTrigger();
            GameManager.gameOver = true;
            gameObject.collider2D.isTrigger = false;
            tmpPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        } else if (other.gameObject.tag == "Roof") {
            Vector3 tempVel = new Vector3 (0f, downVel / 5, 0f);
            rigidbody2D.velocity = tempVel;
        }

        if (GameManager.gameStop || GameManager.gameOver) {
            fadeComp.MakeFlashLight(0.3f);
        }

        if (GameManager.gameOver) {
            if (GameManager.score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore", GameManager.score);
                GameManager.medal = true;
            }
            GameManager.gameOver = true;
        }
    }

    void SendCollidePosition() {
        // Get the position when the bird collied first
        if (collidedTime == 0) {
            fadeComp.collidePosition = cameraComp.WorldToScreenPoint (transform.position);
        }
        collidedTime++;
    }
}
