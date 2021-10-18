using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject hitEffect;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        this.gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {
        Ball ball = hitInfo.transform.GetComponent<Ball>();
        if (ball != null) {
            this.gameManager.addScorePoints();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
