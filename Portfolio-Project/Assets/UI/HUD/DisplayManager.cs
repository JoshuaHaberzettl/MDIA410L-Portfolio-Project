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
    public static int EnemiesTotal;
    
    // Start is called before the first frame update
    void Start()
    {
        EnemiesTotal = 25;
        EnemiesLeft = EnemiesTotal;
        
    }

    // Update is called once per frame
    void Update()
    {

        setTime();
        HighScore.text = Saving.Instance.GetHighScore();
        EnemyCounter.text = "Enemies: "+ EnemiesLeft.ToString() + "/" + EnemiesTotal.ToString();
        
    }

    void getTime()
    {
        timer.text = Timer.TimerText; //Need a trigger to stop updating
    }
    void setTime()
    {
        Invoke("getTime", .5f);
    }

    
}
