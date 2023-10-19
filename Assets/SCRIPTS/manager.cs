using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class manager : MonoBehaviour
{
    public Light[] dalights;
    public player playr;
    public int duration = 60;
    public int timeRemaining;
    private bool countingDown = false;
    public bool day = true;
    public int nightNum = 0;

    public headDrone drone1;
    public headDrone drone2;
    public cashierscript cashier;
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
        day = !day;
        if (day)
        {
            duration = 15;
        dalights[0].intensity = 1; dalights[1].intensity = 1; dalights[2].intensity = 1; dalights[3].intensity = 1;
        drone1.deactivate();
        drone2.deactivate();
        }
        else
        {
            duration = 60;
        cashier.askForItem();
        dalights[0].intensity = 0; dalights[1].intensity = 0; dalights[2].intensity = 0; dalights[3].intensity = 0;
        nightNum++;
            if (nightNum > 0) 
            {
                drone1.activate(); 
            }
            if (nightNum > 1)
            {
                drone1.activate();
                drone2.activate();
            }
            if (nightNum > 3)
            {
                SceneManager.LoadScene("credits");
            }
        }
        countingDown = false;
        startTimer();
    }
    public void setShoes()
    {
        print("got shoes");
        playr.sprintSpeed = 7;
    }


}
