using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class player : MonoBehaviour
{
    public Camera cam;
    public float speed;
    public float score;
    public Rigidbody rb;
    public Vector2 inputVector;
    private Vector3 offset = new Vector3(0, 0, -10);

    // Update is called once per frame
    void Update()
    {
        score = Time.deltaTime;
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Forward"));
        rb.velocity = (inputVector.normalized) * speed;
    }
}