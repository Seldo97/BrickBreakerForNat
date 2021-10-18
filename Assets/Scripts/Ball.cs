using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody2D ballRigidbody;
    public float moveSpeed = 300f;
    public Transform playerTransform;
    private bool inPlay = false;

    // Start is called before the first frame update
    void Start() {
        // this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (!this.inPlay) {
            transform.position = playerTransform.position;
        }

        if (Input.GetButtonDown("Jump")) {
            this.setBallInPlay();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("BottomWall")) {
            this.resetBall();
        }
    }

    public void resetBall() {
        ballRigidbody.velocity = Vector2.zero;
        this.inPlay = false;
    }

    public void setBallInPlay() {
        this.inPlay = true;
        this.ballRigidbody.AddForce(Vector2.up * moveSpeed);
    }
}
