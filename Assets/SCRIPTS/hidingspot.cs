using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class hidingspot : MonoBehaviour
{
    public bool destroyed = false;
    public manager bossman;
    public BoxCollider box;
    public TextMeshPro words;
    public player playr;
    public GameObject goolio;
    public bool hidingHere;
    public float timeHiddenHere;
    private int timeLimit = 5;
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
        if (other.tag == "Player")
        {
            words.text = "Press E to hide at night!";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) & !bossman.day)
            {
                words.text = "You're hiding!";
                hidingHere= true;
                playr.hidden = true;
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
        words.text = "";
        Instantiate(goolio, transform.position, new Quaternion(0,0,0,0));
        hidingHere = false;
        destroyed = true;
        playr.hidden = false;
    }

}