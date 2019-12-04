 using UnityEngine;
using System.Collections;
using System;

public class DataMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;

   public bool hasQuit;

    public int intDifference; 
    void Start()
    {
        hasQuit = false;
        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        //Grab the old time from the player prefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        Debug.Log("oldDate: " + oldDate);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        Debug.Log("Difference: " + difference);

        intDifference = (int)difference.TotalSeconds;
        Debug.Log("Difference in Int" + intDifference);

    }

    void OnApplicationPause()
    {
        hasQuit = true; 


        //Savee the current system time as a string in the player prefs class
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());

        print("Saving this date to prefs: " + System.DateTime.Now);
    }

}