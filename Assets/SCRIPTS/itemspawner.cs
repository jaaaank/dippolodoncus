using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class itemspawner : MonoBehaviour
{
    public GameObject itempickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomSpawner()
    {
        int positionnumbr = Random.Range(1, 11);
        switch (positionnumbr)
        {
            case 1:
                spawnit(new Vector3(-1.37f, 0.33f, 5.4f));
                break;
            case 2:
                spawnit(new Vector3(-3.5f, 0.5f, 7.2f));
                break;
            case 3:
                spawnit(new Vector3(-10.9f, 0.5f, 18f));
                break;
            case 4:
                spawnit(new Vector3(-8.4f, 0.5f, 15.2f));
                break;
            case 5:
                spawnit(new Vector3(4.53f, 0.5f, 16.7f));
                break;
            case 6:
                spawnit(new Vector3(8.1f, 0.5f, -2.587f));
                break;
            case 7:
                spawnit(new Vector3(10.3f, 0.5f, 1.27f));
                break;
            case 8:
                spawnit(new Vector3(11.26f, 0.5f, 19.7f));
                break;
            case 9:
                spawnit(new Vector3(-7.11f, 0.5f, -8.875f));
                break;
            case 10:
                spawnit(new Vector3(2.8f, 0.5f, -0.3f));
                break;
        }
    }

    public void spawnit(Vector3 snoob)
    {
        Instantiate(itempickup, snoob, itempickup.transform.rotation);
    }

}
