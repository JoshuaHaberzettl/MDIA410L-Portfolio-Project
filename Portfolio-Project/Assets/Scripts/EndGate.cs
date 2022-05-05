using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour
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

        if (other.tag == "Player" && myTimer.seconds > 1f && Timer.TimerStarted == true)
        {
            Debug.Log("Stop");
            myTimer.changeTimerState();
            //Record Time here for leaderboards
        }





    }
}
