using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    void OnCollisionEnter2D(Collision2D hitInfo) {
        Ball ball = hitInfo.transform.GetComponent<Ball>();
        if (ball != null) {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
