using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    public Text winText;
    private int score = 0;
    private int destroyedBricks = 0;
    private Brick[] bricks;
    private FllingHeartSpawner fllingHeartSpawner;
    // Start is called before the first frame update
    void Start() {
        this.bricks = Object.FindObjectsOfType<Brick>();
        this.fllingHeartSpawner = Object.FindObjectOfType<FllingHeartSpawner>();
        this.winText.enabled = false;
        this.setScoreText();
    }

    // Update is called once per frame
    void Update() {
    }

    public void addScorePoints() {
        this.destroyedBricks += 1; ;
        this.score += 1;
        this.setScoreText();

        if (this.bricks.Length == this.destroyedBricks) {
            this.winGame();
        }
    }

    public void winGame() {
        this.fllingHeartSpawner.startSpawningPrefabs();
        this.winText.enabled = true;
    }

    private void setScoreText() {
        this.scoreText.text = "Punkty miłości: " + this.score;
    }
}
