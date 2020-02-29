using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    private bool[][] field;

    private float spawnDelay = 5f;

    private float spawnInterval = 4f;

    private int fieldSize = 0;

    private int cellSize = 2;


    public void StartEnemiesSpawing(bool[][] inputField, int spawners = 2) {
        field = inputField;
        fieldSize = inputField.Length;

        for (int i = 0; i < spawners; i += 1) {
            InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        }
    }

    public void SpawnEnemy() {
        bool toAdd = true;
        while (toAdd) {
            int i = Random.Range(0, fieldSize);
            int j = Random.Range(0, fieldSize);

            if (!field[i][j]) {
                Instantiate(
                    enemyPrefab,
                    new Vector3((i - (fieldSize / 2)), 0, (j - (fieldSize / 2))) * cellSize,
                    Quaternion.identity
                );
            }
        }

        if (spawnInterval > 0) spawnInterval -= 0.2f;
    }

    public void StopEnemiesSpawing() {
        CancelInvoke("SpawnEnemy");
    }
}
