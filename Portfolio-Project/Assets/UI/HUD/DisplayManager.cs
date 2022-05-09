using System;
using System.Collections;
using System.Collections.Generic;
using Save;
using UnityEngine;
using TMPro;

public class DisplayManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI EnemyCounter;
    public TextMeshProUGUI HighScore;
    public static int EnemiesLeft;
    private int _enemiesTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemiesTotal = 26;
        EnemiesLeft = _enemiesTotal;
        
    }

    // Update is called once per frame
    void Update()
    {
        GetTime();
        HighScore.text = Saving.Instance.GetHighScore();
        EnemyCounter.text = EnemiesLeft.ToString() + "/" + _enemiesTotal.ToString();
    }

    private void GetTime()
    {
        timer.text = Timer.TimerText; 
    }
    
    /*
    void setTime()
    {
        Invoke("getTime", .5f);
    }
    */

    
}
