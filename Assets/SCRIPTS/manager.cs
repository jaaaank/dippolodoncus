using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public SpriteRenderer woman1;
    public SpriteRenderer woman2;
    public cashierscript cashier;
    public itemspawner cashierspawner;
    public shopper shopper1;
    public shopper shopper2;
    public shopper shopper3;
    public shopper shopper4;
    public TextMeshProUGUI uitext;
    public TextMeshProUGUI daytext;
    public AudioSource ramsay;
    public AudioSource fuckingryan;

    public bool hasShoes{set{setShoes();}}
    public int bananas = 0;
    public int skateboards = 0;
    public int money = 0;

    void Start()
    {
        woman2.enabled = false;
        startTimer();
        shopper1.unityanimatorsucksdick.SetBool("daytime", day);
        shopper1.dontyouwannagoapeshit();
        shopper2.unityanimatorsucksdick.SetBool("daytime", day);
        shopper1.dontyouwannagoapeshit();
        shopper3.unityanimatorsucksdick.SetBool("daytime", day);
        shopper1.dontyouwannagoapeshit();
        shopper4.unityanimatorsucksdick.SetBool("daytime", day);
        shopper1.dontyouwannagoapeshit();
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
        shopper1.unityanimatorsucksdick.SetBool("daytime", day);
        shopper2.unityanimatorsucksdick.SetBool("daytime", day);
        shopper3.unityanimatorsucksdick.SetBool("daytime", day);
        shopper4.unityanimatorsucksdick.SetBool("daytime", day);
        if (day)
        {
            fuckingryan.Play();
            woman1.enabled = true;
            if (nightNum >= 2)
            {
                woman2.enabled = true;
            }
            daytext.text = "Day: " + (nightNum+1).ToString();
            cashier.dayInterrupted();
            playr.hasItem = false;
            GameObject[] bananerFabs = GameObject.FindGameObjectsWithTag("itempickup");
            foreach (GameObject obj in bananerFabs)
            {
                Destroy(obj);
            }
            duration = 15;
        shopper1.dontyouwannagoapeshit();
        shopper2.dontyouwannagoapeshit();
        shopper3.dontyouwannagoapeshit();
        shopper4.dontyouwannagoapeshit();
        dalights[0].intensity = 1; dalights[1].intensity = 1; dalights[2].intensity = 1; dalights[3].intensity = 1;
        drone1.deactivate();
        drone2.deactivate();
        }
        else
        {
            fuckingryan.Stop();
            ramsay.Play();
            woman1.enabled = false;
            woman2.enabled = false;
            daytext.text = "Night: " + (nightNum + 1).ToString();
            shopper1.dontyouwannajustfuckingloseit();
            shopper2.dontyouwannajustfuckingloseit();
            shopper3.dontyouwannajustfuckingloseit();
            shopper4.dontyouwannajustfuckingloseit();
            duration = 60;
        cashier.askForItem();
            uitext.text = "THE CASHIER CRAVES A BANANER";
        dalights[0].intensity = 0; dalights[1].intensity = 0; dalights[2].intensity = 0; dalights[3].intensity = 0;
        nightNum++;
            if (nightNum > 0) 
            {

                drone1.activate(); 
            }
            if (nightNum > 1)
            {
                drone1.activate();
                shopper2.activate();
            }
            if (nightNum > 2)
            {
                drone1.activate();
                drone2.activate();
                shopper2.activate();
                shopper3.activate();
                shopper4.activate();
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
