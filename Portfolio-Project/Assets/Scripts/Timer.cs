using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public int minutes;

    public float seconds;

    public static string timerText;

    public static bool TimerStarted;
    // Start is called before the first frame update
    void Start()
    {
       ResetTimer();
    }

    void FixedUpdate()
    {
        if (TimerStarted == true)
        {
            StartTimer();
        }
    }
    // Update is called once per frame
    public void StartTimer()
    {
        
        secondsPassed();
        minutesPassed(seconds);
        timerText = TimeDisplayText(minutes,seconds);
    }

    public void ResetTimer()
    {
        TimerStarted = false;
        minutes = 0;
        seconds = 0f;
    }

    public int minutesPassed(float secondscounted)
    {
        
        if (Time.timeScale>0 && secondscounted >= 60)
        {
            minutes += 1;
            seconds = 0;
        }

        return minutes;
    }

    public float secondsPassed()
    {
        if (Time.timeScale > 0 && TimerStarted==true)
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
            string MyTimer = minutesText + ":0" + secondsText;
            return MyTimer;
        }
        else
        {
            string MyTimer = minutesText + ":" + secondsText;
            return MyTimer;
        }
        
        
    }

    public void changeTimerState()
    {
        TimerStarted = !TimerStarted;
    }

   

   
}
