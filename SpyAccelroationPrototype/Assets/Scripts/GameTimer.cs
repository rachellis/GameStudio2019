using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Countdowns from 20 Minutes currently. 
/// </summary>
public class GameTimer : MonoBehaviour
{
    //Add the text you want to display the time here
    public Text timerText;
    // The time in seconds you want to count down from.
    public float time = 1200;

    void Start()
    {
        Debug.Log("Here ;P");
        StartCoundownTimer();
    }

    /// <summary>
    /// Makes the timer start and continue until the itme is at 0
    /// </summary>
    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: 20:00:000";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    /// <summary>
    /// Does math to display the time in minues, seconds, and fractions of seconds.
    /// </summary>
    void UpdateTimer()
    {
        //If you run out of time, stop the game
        if (time == 0)
        {
            Time.timeScale = 0;
        }
        if (timerText != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string fraction = ((time * 100) % 100).ToString("000");
            timerText.text = "Time Left: " + minutes + ":" + seconds + ":" + fraction;
        }
    }
}
