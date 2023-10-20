using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class agressiveenemy : MonoBehaviour
{
    private Vector3 target;
    public player playr;
    public float speed;
    public SpriteRenderer sprite;
    public bool caught = false;
    public Vector3 startingPos;
    private Vector3 lostOffset = new Vector3(0,0,-.8f);
    public AudioSource giveupnoise;

    private void Start()
    {
        target = transform.position;
        startingPos = transform.position;
    }
    void Update()
    {
        if (playr.hidden & caught)
        {
            target = playr.gameObject.transform.position + lostOffset;
            Invoke("giveUp", 4.5f);
        }
        if (!playr.hidden & caught)
        {
            target = playr.gameObject.transform.position;
        }
        if (target.x - transform.position.x >= 0)
        {
            sprite.flipX = false;
        }
        if (target.x - transform.position.x < 0)
        {
            sprite.flipX = true;
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
            Destroy(playr.gameObject);
            SceneManager.LoadScene("gameover");
        }
    }
    private void giveUp()
    {
        giveupnoise.Play();
        target = startingPos;
        caught = false;
    }
}
