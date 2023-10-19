using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class player : MonoBehaviour
{
    public manager bossman;
    private bool sprinting = false;
    public float stamina;
    public float maxStamina;
    public float speed;
    public Rigidbody rb;
    public SpriteRenderer sprite;
    public Vector3 inputVector;
    public SphereCollider skateboard;
    public int sprintSpeed;
    public bool hidden;
    public Animator unityanimatorsucksdick;
    public GameObject nanner;
    public bool hasItem=false;

    private void Start()
    {
        skateboard.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!hidden)
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
                    speed = sprintSpeed;
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
                speed = 4;
                if (stamina < maxStamina)
                {
                    stamina += 1 * Time.deltaTime;
                }
            }
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            rb.velocity = (inputVector.normalized) * speed;
            if (Input.GetKeyDown(KeyCode.Space) & !skateboard.enabled & bossman.skateboards > 0)
            {
                bossman.skateboards -= 1;
                skateboard.enabled = true;
                //this is a dumb way of doing this but it works and its all i can think of for now
                Invoke("stopAttacking", 0.5f);
            }
            if (rb.velocity.x > 0)
            {
                sprite.flipX = true;
            }
            if (rb.velocity.x < 0)
            {
                sprite.flipX = false;
            }
            unityanimatorsucksdick.SetFloat("velocity", Mathf.Abs(rb.velocity.magnitude));
        }
    }
    private void stopAttacking()
    {
        skateboard.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger & other.tag == "shopper")
        {
            Destroy(other.gameObject);
        }
        if (other.isTrigger & other.tag == "itempickup")
        {
            hasItem = true;
            Destroy(other.gameObject);
        }
        //do something to the enemy here; move it somewhere, kill it, send it some signal idk, we'll get there once adam/tire finish the enemy designs/ideas
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "hidingspot")
        {
            if(Input.GetKey(KeyCode.E))
            {
                //idk if im gonna keep this we'll see how the others like it
                sprite.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                hidden = true;
                rb.velocity = Vector3.zero;
                unityanimatorsucksdick.SetFloat("velocity", 0.0f);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "hidingspot")
        {
            //idk if im gonna keep this we'll see how the others like it;;; maybe just zoom in the camera?
            sprite.transform.localScale = Vector3.one;
            hidden = false;
        }
    }

}