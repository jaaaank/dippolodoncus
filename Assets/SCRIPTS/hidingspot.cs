using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class hidingspot : MonoBehaviour
{
    public TextMeshPro words;
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
        words.text = "Press E to hide!";
    }
    private void OnTriggerExit(Collider other)
    {
        words.text = "";
    }
}
