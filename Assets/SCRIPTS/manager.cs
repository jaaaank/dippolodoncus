using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public int duration = 60;
    private int timeRemaining;
    private bool countingDown = false;
    public bool day = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
    }

}
