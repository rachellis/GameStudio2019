﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MutualCountdown : MonoBehaviour
{
    public Text countdownText;

    public Button startButton;

    public Button hideText; 

    private float countdownNumber;

    private float newTime; 

    private bool hasPressed = false;

    private bool hidingTime = false;


    private void Tick()
    {
        newTime = Time.deltaTime;
        Debug.Log(newTime);

    }

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

    private IEnumerator Countdown(float countdownTime)
    {
        countdownText.gameObject.SetActive(true);

        while (countdownTime >= 1f)
        {
            Debug.Log("LLLOOOP");
            countdownTime -= (Time.deltaTime);
            int printInt = (int)(countdownTime) % 60;
            int mins = ((int)(countdownTime - printInt) / 60);
            countdownText.text = "Syncronize: " + mins.ToString() + ":" + printInt.ToString();
            yield return null;
        }
        
        hasPressed = true;

        countdownText.gameObject.SetActive(false);
    }

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

    private void Update()
    {
        /*


        if (countdownNumber <= 0 && hasPressed && !hidingTime)
        {
            Debug.Log("sdjshdjdh");
            startHiding();
            countdownText.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            hideText.gameObject.SetActive(false);
        } */

    }
}