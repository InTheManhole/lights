using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject groundPrefab;

    public GameObject enemyPrefab;

    public GameObject playerPrefab;

    public GameObject[] obstaclesPrefabs;

    public int size = 50;


    private GroundBuilder ground;

    private GameObject player;


    void Start() {
        // Init ground
        gameObject.AddComponent<GroundBuilder>();
        ground = gameObject.GetComponent<GroundBuilder>();

        ground.BuildGround(size);

        // Add player
        player = Instantiate(playerPrefab, new Vector3(0f, 1f, 0f), Quaternion.identity);
        player.AddComponent<Player>();
    }

    // Update is called once per frame
    void Update() {

    }
}
