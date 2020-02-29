using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBuilder : MonoBehaviour {
    private GameObject planePrefab;

    private GameObject[] obstaclePrefabs;

    private List<GameObject> allObjects;

    private GameObject ground;

    private int border = 5;

    private int size = 0;

    private int cellSize = 2;

    public bool[][] groundMatrix;


    public void setPrefabs(GameObject plane, GameObject[] obstacles) {
        planePrefab = plane;
        obstaclePrefabs = obstacles;
    }


    public void BuildGround(int inputSize = 50) {
        DestroyGround();
        size = inputSize;

        // Init plane
        ground = Instantiate(planePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ground.transform.localScale += new Vector3(size + border, 0, size + border);

        PopulateObstacles();
    }

    bool isInBorder(int index, int size) {
        return (index <= border) || (index >= (size - (border * 2)));
    }

    void AddObstacle(int i, int j) {
        int halfSize = (size + (border * 2)) / 2;
        GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject instantiatedObstacle = Instantiate(obstacle, new Vector3((i - halfSize) * cellSize, 0, (j - halfSize) * cellSize), Quaternion.identity);
        allObjects.Add(instantiatedObstacle);
    }

    private void PopulateObstacles() {
        int fullSize = size + (border * 2);
        groundMatrix = new bool[size][];
        int halfSize = fullSize / 2;

        for (int i = 0; i < fullSize; i += 1) {
            groundMatrix[i] = new bool[fullSize];

            for(int j = 0; j < fullSize; j += 1) {
                if (isInBorder(i, fullSize) || isInBorder(j, fullSize)) {
                    groundMatrix[i][j] = true;
                } else if (i == halfSize && j == halfSize) {
                    groundMatrix[i][j] = false;
                } else {
                    groundMatrix[i][j] = (
                        Random.Range(0f, 1f) < Utils.CurveCoefficient(i, fullSize)
                        && Random.Range(0f, 1f) < Utils.CurveCoefficient(j, fullSize)
                    );
                }

                if (groundMatrix[i][j]) AddObstacle(i, j);
            }
        }
    }

    public void DestroyGround() {
        Destroy(ground);
        size = 0;
        foreach(GameObject obj in allObjects.ToArray()) Destroy(obj);
        allObjects.Clear();
    }
}
