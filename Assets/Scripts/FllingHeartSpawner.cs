using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FllingHeartSpawner : MonoBehaviour {
    public GameObject prefab;
    public float respawnIntervalTime = 0.6f;
    public float spawnRangeMargin = 3f;
    public float screenSpawnRangeBorder = 3f;
    private Vector2 screenBounds;
    private Vector2 spawnedObjPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start() {
        this.screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                Camera.main.transform.position.z
            )
        );
    }

    public void startSpawningPrefabs() {
        StartCoroutine(this.EnemyWave());
    }

    private void SpawnEnemy() {
        GameObject obj = Instantiate(this.prefab) as GameObject;

        bool isSpawnPositionCorrect = false;
        Vector2 tempSpawnPosition;

        while (!isSpawnPositionCorrect) {
            float scale = Random.Range(0.07f, 0.2f);
            obj.transform.localScale = new Vector3(scale, scale, 1);
            tempSpawnPosition = new Vector2(
                Random.Range((-this.screenBounds.x + this.screenSpawnRangeBorder), (this.screenBounds.x - this.screenSpawnRangeBorder)),
                this.gameObject.transform.position.y
            );

            if (Math.Abs(tempSpawnPosition.x - this.spawnedObjPosition.x) >= this.spawnRangeMargin) {
                this.spawnedObjPosition = tempSpawnPosition;
                isSpawnPositionCorrect = true;
            }
        }

        obj.transform.position = this.spawnedObjPosition;
    }

    private IEnumerator EnemyWave() {
        while (true) {
            yield return new WaitForSeconds(this.respawnIntervalTime);
            this.SpawnEnemy();
        }
    }
}
