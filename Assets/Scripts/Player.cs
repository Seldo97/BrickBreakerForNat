using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start() {
        this.setPlayerStartupPosition();
    }

    // Update is called once per frame
    void Update() {
        float moveDirectionX = Input.GetAxis("Horizontal");
        playerRigidbody.velocity = new Vector2(moveDirectionX * moveSpeed, playerRigidbody.velocity.y);
    }

    public void setPlayerStartupPosition() { 
        playerRigidbody.position = new Vector2(0, -4);
    }
}
