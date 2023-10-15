using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class aisleSensor : MonoBehaviour
{
    public manager dabossu;
    public shopper shoppa;
    public bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & !dabossu.day)
        {
            shoppa.agressive = true;
            shoppa.speed = 4;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" & !dabossu.day)
        {
            shoppa.agressive = false;
            shoppa.speed = 1;
        }
        if(other.tag == "shopper")
        {
            shoppa.speed = -shoppa.speed;
        }
    }

}
