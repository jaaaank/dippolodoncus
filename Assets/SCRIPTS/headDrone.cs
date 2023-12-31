using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headDrone : MonoBehaviour
{
    public agressiveenemy body;
    private Vector3 target;
    public float speed;
    public SpriteRenderer sprite;
    public AudioSource alarm;
    private bool activated=false;
    public player playr;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (target.x - transform.position.x >= 0)
        {
            sprite.flipX = true;
        }
        if (target.x - transform.position.x < 0)
        {
            sprite.flipX = false;
        }
    }


    public void randomTarget()
    { 
        int randx = Random.Range(-11, 20);
        int randz = Random.Range(-12, 13);
        target = new Vector3 (randx, 1.6f, randz);
        Invoke("randomTarget", 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & !playr.hidden)
        {
            target = other.transform.position;
            alarm.Play();
            body.caught = true;
            //activate the body
        }
    }
    public void activate()
    {
        activated = true;
        randomTarget();
    }
    public void deactivate()
    {
        activated = false;
        CancelInvoke();
        transform.Translate(-30,0,0);
    }
}
