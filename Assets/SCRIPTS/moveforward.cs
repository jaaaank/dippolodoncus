using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class moveforward : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5.0f);
        //transform.Rotate(0,0, Random.Range(-4.0f, 4.0f)); random spread but i dont really want that 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
