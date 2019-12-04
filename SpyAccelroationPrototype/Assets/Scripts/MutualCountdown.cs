using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Timer system for the game. Handles both timers
/// </summary>
public class MutualCountdown : MonoBehaviour
{
    // Collects many objects to control the buttons and text
    public Text countdownText;

    public Text gameCountdownText;

    public Image Information;

    public Image Warning;

    public Button startButton;

    public Button hideText;

    // Some other bools and variables to keep. Some don't matter
    private float countdownNumber;

    private float newTime; 

    private bool hasPressed = false;

    private bool hidingTime = false;


    [SerializeField] private DataMaster dateStuff;

    /// <summary>
    /// Updates the time every frame
    /// </summary>
    private void Tick()
    {
        newTime = Time.deltaTime;
        Debug.Log(newTime);

    }

    /// <summary>
    /// Starts the setup countdown
    /// </summary>
    /// <param name="countdownTime">Amount of time in seconds for the timer</param>
    public void startCountdown(float countdownTime)
    { /*

        countdownNumber -= Time.deltaTime;

        int seconds = ((int)countdownNumber % 60);
        */
        Debug.Log("Button Pushed");
        /*
        countdownNumber = 6f;

        countdownText.gameObject.SetActive(true); */
        StartCoroutine(Countdown(countdownTime));

    }

    /// <summary>
    /// Starts the main countdown
    /// </summary>
    /// <param name="countdownTime">>Amount of time in seconds for the timer</param>
    public void startGameCountdown(float countdownTime) {
        StartCoroutine(GameCountdown(countdownTime));
    }

    /// <summary>
    /// Counts down during the setup phase.
    /// </summary>
    /// <param name="countdownTime">Amount of time in seconds for the timer</param>
    /// <returns>Null, frame countdown</returns>
    private IEnumerator Countdown(float countdownTime)
    {
        countdownText.gameObject.SetActive(true);

        while (countdownTime >= 1f)
        {

            countdownTime -= (Time.deltaTime);

            // Formatting items
            int printInt = (int)(countdownTime) % 60;
            int mins = ((int)(countdownTime - printInt) / 60);
            string s = "{0}:{1:00}";
            string c_time = string.Format(s, mins, printInt);
            // Setting text to time
            countdownText.text = c_time;
            yield return null;
        }


        // After the countdown is up, update the game to go to the warning screen
        hasPressed = true;

        countdownText.gameObject.SetActive(false);
        Information.gameObject.SetActive(false);

        hideText.gameObject.SetActive(true);
        Warning.gameObject.SetActive(true);
    }

    /// <summary>
    /// Coundowns the main game
    /// </summary>
    /// <param name="countdownTime">Amount of time in seconds for the timer</param>
    /// <returns>Null, frame countdown</returns>
    private IEnumerator GameCountdown(float countdownTime)
    {
        while (countdownTime >= 1f)
        {
            // Check if the game has been closed
            if (dateStuff.hasQuit)
            {
                Debug.Log("I am getting here even though I should not be hahahah");
                countdownTime -= dateStuff.intDifference;
                dateStuff.hasQuit = false; 
            }

            // Change the time
            countdownTime -= (Time.deltaTime);
            // Formatting the time
            int printInt = (int)(countdownTime) % 60;
            int mins = ((int)(countdownTime - printInt) / 60);
            string s = "{0}:{1:00}";
            string c_time = string.Format(s, mins, printInt);
            //Changing the text
            gameCountdownText.text = c_time;
            yield return null;
        }
        // If there was something to do after the game it done
        // This is where it would go
    }

    /// <summary>
    /// Seemingly uneeded begin to hiding phase. Won't delete just in case
    /// </summary>
    public void startHiding()
    {
        if (!hidingTime)
        {
            countdownNumber = 300f;

            hideText.gameObject.SetActive(true);

            countdownText.gameObject.SetActive(true);

            hidingTime = true;
        }

    }

    
    /// <summary>
    /// Starts a flashing animation
    /// </summary>
    /// <param name="item">Gameobject to animate</param>
    public void flashItem(GameObject item)
    {
        StartCoroutine("flash", item);
    }

    /// <summary>
    /// A coroutinue ran flashing animation for an obkect
    /// </summary>
    /// <param name="item">Gameobject to animate</param>
    /// <returns>Wait for seconds</returns>
    private IEnumerator flash(GameObject item)
    {
        yield return new WaitForSeconds(1);
        item.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        item.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        item.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        item.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        item.SetActive(false);
        yield return new WaitForSeconds(0.05f);
        item.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        item.SetActive(false);
    }
}
