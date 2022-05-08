using UnityEngine;

public class Timer : MonoBehaviour
{
    public int minutes;

    public float seconds;

    public static string TimerText;

    public static bool TimerStarted;
    
    void Start()
    {
       ResetTimer();
    }

    void FixedUpdate()
    {
        if (TimerStarted)
        {
            StartTimer();
        }
    }
    
    public void StartTimer()
    {
        SecondsPassed();
        MinutesPassed(seconds);
        TimerText = TimeDisplayText(minutes,seconds);
    }

    public void ResetTimer()
    {
        TimerStarted = false;
        minutes = 0;
        seconds = 0f;
    }

    public int MinutesPassed(float secondscounted)
    {
        if (Time.timeScale>0 && secondscounted >= 60)
        {
            minutes += 1;
            seconds = 0;
        }

        return minutes;
    }

    public float SecondsPassed()
    {
        if (Time.timeScale > 0 && TimerStarted)
        {
            seconds += 1*Time.deltaTime;
        }

        return seconds;
    }

    

    public string TimeDisplayText(int minutes, float seconds)
    {
        string minutesText = minutes.ToString();
        string secondsText = seconds.ToString();
        if (seconds < 10)
        {
            string myTimer = minutesText + ":0" + secondsText;
            return myTimer;
        }
        else
        {
            string myTimer = minutesText + ":" + secondsText;
            return myTimer;
        }
        
        
    }

    public void changeTimerState()
    {
        TimerStarted = !TimerStarted;
    }

   

   
}
