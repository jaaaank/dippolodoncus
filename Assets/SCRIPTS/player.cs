using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class player : MonoBehaviour
{
    private bool sprinting = false;
    public float stamina;
    public float maxStamina;
    public float speed;
    public Rigidbody rb;
    public Vector3 inputVector;
    public SphereCollider skateboard;

    private void Start()
    {
        skateboard.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
        }
        if (sprinting)
        {
            if (stamina > 0)
            {
               speed = 10;
               stamina -= 1 * Time.deltaTime;
            }
            else
            {
                sprinting = false;
                stamina = -2;
            }
        }
        if (!sprinting)
        {
            speed = 5;
            if (stamina<maxStamina)
            {
                stamina += 1 * Time.deltaTime;
            }
        }
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = (inputVector.normalized) * speed;
        if (Input.GetKeyDown(KeyCode.Space)&!skateboard.enabled)
        {
            skateboard.enabled = true;
            //this is a dumb way of doing this but it works and its all i can think of for now
            Invoke("stopAttacking", 0.5f);
        }
    }
    private void stopAttacking()
    {
        skateboard.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            Destroy(other.gameObject);
        }
        //do something to the enemy here; move it somewhere, kill it, send it some signal idk, we'll get there once adam/tire finish the enemy designs/ideas
    }

}