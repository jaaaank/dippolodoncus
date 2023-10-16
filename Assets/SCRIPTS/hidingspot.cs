using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class hidingspot : MonoBehaviour
{
    public bool destroyed = false;
    public BoxCollider box;
    public TextMeshPro words;
    public player playr;
    public bool hidingHere;
    public float timeHiddenHere;
    private int timeLimit = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hidingHere)
        {
            timeHiddenHere += Time.deltaTime;
            if (timeHiddenHere > timeLimit)
            {
                kickout();
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        words.text = "Press E to hide!";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("shoob");
            if (Input.GetKey(KeyCode.E))
            {
                words.text = "You're hiding!";
                hidingHere= true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        words.text = "";
        hidingHere= false;
        if (destroyed)
        {
         box.enabled = false;
        }
    }
    public void kickout()
    {
        hidingHere = false;
        destroyed = true;
        playr.hidden = false;
        words.text = "you got kicked out this text is temporary";
    }

}