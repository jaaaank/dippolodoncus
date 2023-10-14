using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class player : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Vector3 inputVector;

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = (inputVector.normalized) * speed;
    }


}