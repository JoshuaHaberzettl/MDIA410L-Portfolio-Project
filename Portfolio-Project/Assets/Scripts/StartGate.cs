using UnityEngine;

public class StartGate : MonoBehaviour
{
    public Timer myTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Timer.TimerStarted)
        {
            Debug.Log("Start");
            myTimer.ResetTimer();
            //also want to reset course here probably
            myTimer.changeTimerState();
        }
    }
}
