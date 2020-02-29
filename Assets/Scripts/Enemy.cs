using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchPlayer : MonoBehaviour {

    private GameObject player;

    private BoxCollider boxColiderTriggerable;
    private BoxCollider boxColiderNotTriggerable;


    public float walkSpeed = 3f;
    public float delay = 2f;

    void Start() {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
        BoxColidersSetup();
        RigidBodySetup();
    }

    void Update() {
        goCloseToPlayer();
    }

    void BoxColidersSetup() {
        boxColiderTriggerable = gameObject.AddComponent<BoxCollider>();
        boxColiderTriggerable.isTrigger = true;
        boxColiderTriggerable.center = new Vector3(0, 0, 0);
        boxColiderTriggerable.size = new Vector3(1, 1, 1);
        boxColiderNotTriggerable = gameObject.AddComponent<BoxCollider>();
        boxColiderNotTriggerable.isTrigger = true;
        boxColiderNotTriggerable.center = new Vector3(0, 0, 0);
        boxColiderNotTriggerable.size = new Vector3(1, 1, 1);
    }

    void RigidBodySetup() {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.mass = 1;
        rigidbody.drag = 0;
        rigidbody.angularDrag = 0.5f;
        rigidbody.useGravity = false;
    }

    void goCloseToPlayer() {
        // Avoid weird rotation and fix height
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        transform.Rotate(Vector3.forward * 0);
        transform.Rotate(Vector3.right * 0);

        // Delay actions
        if (delay > 0) {
            delay -= Time.deltaTime;
            return;
        }

        transform.LookAt(player.transform.position);
        transform.position += transform.forward * walkSpeed * Time.deltaTime;
    }

    void PlayerCaught() {
        Debug.Log("Player Cought");
        // Stop game
    }

    void ObstacleHit() {
        Debug.Log("Obstacle Hit");
        // Destroy enemy
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tags.PLAYER) {
            PlayerCaught();
        } else if (other.gameObject.tag == Tags.OBSTACLE) {
            ObstacleHit();
        }
    }


}
