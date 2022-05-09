using System.Collections.Generic;
using Sound;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    public Timer myTimer;
    public List<GameObject> enemies;
    public List<GameObject> doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !Timer.TimerStarted)
        {
            Debug.Log("Start");
            myTimer.ResetTimer();
            myTimer.changeTimerState();
            
            // Reset course
            foreach (var enemy in enemies)
            {
                enemy.SetActive(true);
            }
            foreach (var door in doors)
            {
                door.SetActive(true);
            }

            SoundManager.Instance.PlayMusic();
        }
    }
}
