using Save;
using Sound;
using UnityEngine;

public class EndGate : MonoBehaviour
{
    public Timer myTimer;
    [SerializeField]
    private GameObject startDoor;
    [SerializeField]
    private GameObject endDoor;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && myTimer.seconds > 1f && Timer.TimerStarted)
        {
            Debug.Log("Stop");
            myTimer.changeTimerState();
            
            // Record Time for leaderboards
            Saving.Instance.Save(myTimer);
            
            // Set up spawn room doors
            startDoor.SetActive(false);
            endDoor.SetActive(true);
            DisplayManager.EnemiesLeft = 26;
            
            SoundManager.Instance.StopMusic();
            SoundManager.Instance.PlayWin();
        }
    }
    
}
