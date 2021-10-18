using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingHeart : MonoBehaviour {

    public Rigidbody2D rb;
    public float fallingSpeedMin;
    public float fallingSpeedMax;

    // Start is called before the first frame update
    void Start() {
        this.rb.velocity = -transform.up * Random.Range(fallingSpeedMin, fallingSpeedMax);;
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("BottomWall")) {
            Destroy(this.gameObject);
        }
    }
}
