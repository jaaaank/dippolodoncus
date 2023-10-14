using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    private Vector3 target;
    public GameObject player;
    public float speed;
    public SpriteRenderer sprite;

    private void Start()
    {
        //SICK i will say referencing other gameobjects/nodes is way easier in unity than in godot 
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (player != null)
        {
            target = player.transform.position;
        }
        if (target.x - transform.position.x >= 0)
        {
            sprite.flipX = true;
        }
        if (target.x - transform.position.x < 0)
        {
            sprite.flipX = false;
        }
        //float AngleRad = Mathf.Atan2(target.z - transform.position.z, target.x - transform.position.x);
        //float angle = (180 / Mathf.PI) * AngleRad;
        //transform.rotation = Quaternion.Euler(0, angle, 0);
        //weird stupid math shit that only works in 2D lol^ below is a way easier way to do it v

        transform.LookAt(target);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(player);
        }
    }
}
