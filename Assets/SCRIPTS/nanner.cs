using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nanner : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 120f);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shopper")
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
