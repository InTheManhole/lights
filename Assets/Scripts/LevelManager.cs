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

    private GameObject playerCamera;


    void Start() {
        // Init ground
        gameObject.AddComponent<GroundBuilder>();
        ground = gameObject.GetComponent<GroundBuilder>();
        ground.setPrefabs(groundPrefab, obstaclesPrefabs);
        ground.BuildGround(size);

        // Add player
        player = Instantiate(playerPrefab, new Vector3(0f, 0.5f, 0f), Quaternion.identity);
        player.AddComponent<Player>();

        // Add Camera
        playerCamera = GameObject.FindGameObjectWithTag(Tags.CAMERA);
        playerCamera.AddComponent<FollowPlayer>();
        playerCamera.GetComponent<FollowPlayer>().offsetX = 0;
        playerCamera.GetComponent<FollowPlayer>().offsetY = 10;
        playerCamera.GetComponent<FollowPlayer>().offsetZ = -10;
        playerCamera.GetComponent<FollowPlayer>().lookAtPlayer = true;
    }

    // Update is called once per frame
    void Update() {

    }
}
