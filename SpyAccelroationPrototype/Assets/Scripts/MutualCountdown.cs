using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutualCountdown : MonoBehaviour
{
    public Text countdownText;

    public Button startButton;

    public Button hideText; 

    private float countdownNumber;

    private bool hasPressed = false;

    private bool hidingTime = false; 


    public void startCountdown()
    {


        countdownNumber = 5f;

        countdownText.gameObject.SetActive(true);

        hasPressed = true;


    }

    public void startHiding()
    {
        countdownNumber = 300f;

        hideText.gameObject.SetActive(true);

        countdownText.gameObject.SetActive(true);

        hidingTime = true;

    }

    private void Update()
    {
        countdownNumber -= Time.deltaTime ;

        int seconds =  ((int) countdownNumber % 60); 

        countdownText.text = "Syncronize: " + seconds.ToString();



        if (countdownNumber <= 0 && hasPressed && !hidingTime)
        {
            Debug.Log("sdjshdjdh");
            countdownText.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
            hideText.gameObject.SetActive(false);
        }

    }
}
