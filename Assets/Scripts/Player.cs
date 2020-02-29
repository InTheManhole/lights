using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float walkSpeed = 5f;
    private float spinSpeed = 1f;

    void Start() {
        gameObject.tag = "Player";

        transform.position = new Vector3(0f, 1f, 0f);        
    }
   
    void Update() {
        Move();
    }

    void Move() {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        // Do not rotate on axis != y
        // transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        // transform.Rotate(Vector3.forward * 0);
        // transform.Rotate(Vector3.right * 0);

        if (hInput != 0) transform.Rotate(Vector3.up * hInput * spinSpeed);
        if (vInput > 0) transform.Translate(Vector3.forward * Time.deltaTime * vInput * walkSpeed);
        if (vInput < 0) transform.Translate(Vector3.forward * Time.deltaTime * vInput * (walkSpeed / 2));
    }
}
