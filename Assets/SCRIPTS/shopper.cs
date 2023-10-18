using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopper : MonoBehaviour
{
    public manager dabossu;
    private Vector3 target;
    public player playr;
    public float speed;
    public SpriteRenderer sprite;
    public Vector3 aisle;
    public bool agressive = false;
    void Start()
    {

    }

    void Update()
    {
        if (playr != null)
        {
            if (agressive & !dabossu.day)
            {
                target = playr.transform.position;
                transform.LookAt(target);
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" & !dabossu.day)
        {
            Destroy(playr.gameObject);
            SceneManager.LoadScene("gameover");
        }
        if (collision.gameObject.tag == "nanner")
        {
            stun();
        }
    }

    public void stun()
    {
        transform.Rotate(90, 0, 0);
        transform.Translate(0, -0.4f, 0);
    }
}
