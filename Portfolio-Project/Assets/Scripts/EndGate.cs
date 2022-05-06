using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour
{
    public Timer myTimer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && myTimer.seconds > 1f && Timer.TimerStarted == true)
        {
            Debug.Log("Stop");
            myTimer.changeTimerState();
            //Record Time here for leaderboards
        }
    }
}
