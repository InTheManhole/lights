using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;

    public bool allowRotation = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER);
    }

    void LateUpdate() {
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);
        if (allowRotation) transform.rotation = player.transform.rotation;
    }
}
