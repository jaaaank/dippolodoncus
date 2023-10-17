using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.U2D;

public class cashierscript : MonoBehaviour
{
    public itemspawner itmspwnr;
    public manager managr;
    public player playr;
    public itemcollector itmclectr;
    public SpriteRenderer sprite;
    public Sprite evilsprite;
    public bool agressive = false;
    private int speed = 7;
    private int timeRemaining;
    private bool countingDown;
    private int duration = 30;
    // Start is called before the first frame update
    void Start()
    {
        askForItem();
    }

    // Update is called once per frame
    void Update()
    {
        if (agressive)
        {
            sprite.sprite = evilsprite;
            itmclectr.enabled = false;
            transform.LookAt(playr.gameObject.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" & agressive)
        {
            Destroy(other.gameObject);
        }
    }

    public void askForItem()
    {
        //play some audio or something
        //put some text on screen or something
        itmspwnr.randomSpawner();
        startTimer();
    }

    public void stopTimer()
    {
        CancelInvoke();
        countingDown = false;
    }

    public void startTimer()
    {
        if (!countingDown)
        {
            countingDown = true;
            timeRemaining = duration;
            Invoke("tick", 1f);
        }
    }

    private void tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("tick", 1f);
        }
        else
        {
            outOfTime();
            countingDown = false;
        }
    }
    public void outOfTime()
    {
        agressive = true;
    }
}