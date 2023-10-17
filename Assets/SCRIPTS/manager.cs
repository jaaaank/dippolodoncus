using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class manager : MonoBehaviour
{
    public Light dalight;
    public player playr;
    public int duration = 5;
    public int timeRemaining;
    private bool countingDown = false;
    public bool day = true;
    public int nightNum = 0;

    public headDrone drone1;
    public itemspawner cashierspawner;

    public bool hasShoes{set{setShoes();}}
    public int bananas = 0;
    public int skateboards = 0;
    public int money = 0;

    void Start()
    {
        startTimer();
    }

    void Update()
    {
        //TEMPORARY TEST CODE TO SEE IF SHOES WORK;;; IT DOES
        if (Input.GetKeyDown(KeyCode.K))
        {
            hasShoes = true;
        }
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

    private  void tick()
    {
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("tick", 1f);
        }
        else
        {
            timerDone();
            countingDown = false;
        }
    }
    public void timerDone()
    {
        day = false;
        dalight.intensity = 0;
        nightNum++;
        if (nightNum > 0) { drone1.activate(); }
    }
    public void setShoes()
    {
        print("got shoes");
        playr.sprintSpeed = 7;
    }


}
