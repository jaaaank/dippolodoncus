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
    // Start is called before the first frame update
    void Start()
    {
        randomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    public void randomTarget()
    { 
        int randx = Random.Range(-11, 12);
        int randz = Random.Range(-12, 13);
        target = new Vector3 (randx, 1.6f, randz);
        Invoke("randomTarget", 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.transform.position;
            alarm.Play();
            body.agressive = true;
            //activate the body
        }
    }
}
