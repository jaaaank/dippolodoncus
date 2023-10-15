using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderingenemy : MonoBehaviour
{
    private Vector3 target;
    public player playr;
    public float speed;
    public SpriteRenderer sprite;
    private bool agressive = false;
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (playr != null & !playr.hidden)
        {
            if (agressive)
            {
                target = playr.transform.position;
                transform.LookAt(target);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            //once we get a map i'll make it actually wander
            if (target.x - transform.position.x >= 0)
            {
                sprite.flipX = true;
            }
            if (target.x - transform.position.x < 0)
            {
                sprite.flipX = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(playr.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            agressive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            agressive = false;
        }
    }
}
