using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class itemcollector : MonoBehaviour
{
    public TextMeshProUGUI uitext;
    public cashierscript cashier;
    public player playr;
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
        if (other.tag == "Player" & playr.hasItem)
        {
        playr.hasItem= false;
        uitext.text = "";
        cashier.stopTimer();
        }
    }
}
