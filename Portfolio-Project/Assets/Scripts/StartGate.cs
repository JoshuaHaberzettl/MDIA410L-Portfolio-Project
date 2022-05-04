using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public Timer myTimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Timer.TimerStarted == false)
        {
            Debug.Log("Start");
            myTimer.ResetTimer();
            //also want to reset course here probably
            myTimer.changeTimerState();
        }
    }
}
