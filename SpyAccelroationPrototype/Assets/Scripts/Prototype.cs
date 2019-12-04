using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Logic script for the beacons and captures
/// </summary>
public class Prototype : MonoBehaviour
{

    public float wait = 4f;

    // Beacon objects
    public GameObject capturePointBadge;

    public GameObject redBeacons;
    public GameObject blueBecaons;

    public GameObject homeBeacon;

    public GameObject lockScreen;
    public GameObject beaconContainer;
    public GameObject homeScreenButton;

    // List of display items
    public List<GameObject> listOfDisplays;

    public List<GameObject> listOfFakeBeacons;

    // Test if player was captured
    private bool hasBeenCaught = false;

    // Count number of becons
    private int numOfBeacons = 0;

    // Keep track of what specifc beacons have been captured
    private Hashtable dictOfBeacons = new Hashtable();

    /// <summary>
    /// Old player capture system.
    /// </summary>
    /// <param name="player">The player being captured (not used)</param>
    /// <remarks>No longer in use</remarks>
    public void capturePlayer(GameObject player)
    {
        player.SetActive(true);

        StartCoroutine(deactivate(player, wait));
    }

    /// <summary>
    /// Called when a player captures a beacon
    /// </summary>
    /// <param name="beacon">Beacon object that was captured</param>
    public void captureTower(GameObject beacon)
    {
        Debug.Log(beacon);
        // Check if the beacon was already captured
        bool test = (bool)dictOfBeacons[beacon];

        // If it wasn't captured
        if (listOfFakeBeacons.Contains(beacon))
        {
            Debug.Log("Fake Beacon");
            beenCaputred();
            beaconContainer.SetActive(false);
            lockScreen.SetActive(true);
            homeScreenButton.SetActive(true);
        }
        else
        {
            if (test == false)
            {
                Handheld.Vibrate();
                dictOfBeacons[beacon] = true;
                numOfBeacons++;
                displayBeacons(numOfBeacons);
            }
        }

    }

    /// <summary>
    /// Decativation for old capture player system
    /// </summary>
    /// <param name="obj">Object to reactivate.</param>
    /// <param name="waitTime">Time to wait.</param>
    /// <returns>WaitForSeconds</returns>
    public IEnumerator deactivate(GameObject obj,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    /// <summary>
    /// Reset becaons after being captured
    /// </summary>
    public void beenCaputred()
    {
        // Creates a temporary hashtable
        // I don't know why this is in place
        // This "should" work without it, but hashtables can be tricky.
        
		Hashtable temp = new Hashtable();
		temp = (Hashtable)dictOfBeacons.Clone();

        // Goes thtrouch the beacon table and sets it to false
        foreach(GameObject obj in temp.Keys)
		{
			dictOfBeacons[obj] = false;
		}

        // Resets number fo beacons and runs the display
        numOfBeacons = 0;
        displayBeacons(numOfBeacons);
    }

    /// <summary>
    /// Changes the beacon display to match the number of beacons caught
    /// </summary>
    /// <param name="numDisplay">Number of beacons to display</param>
    private void displayBeacons(int numDisplay)
    {
        // Set all displays to be off
		for (int i = 0; i < listOfDisplays.Count; i++)
		{
			listOfDisplays[i].SetActive(false);
		}
        // Set numDisplay to be on
        for (int i = 0; i < numDisplay; i++)
        {
            listOfDisplays[i].SetActive(true);
        }
    }

    /// <summary>
    /// Vibrates
    /// </summary>
    public void vibrate()
    {
        Handheld.Vibrate();
    }

    /// <summary>
    /// Sets the team for the player
    /// </summary>
    /// <param name="isRedTeam">Tests if red team</param>
    public void setTeam(bool isRedTeam)
    {
        // Sets the target beacons to the blue team, is on red
        if (isRedTeam)
        {
            foreach (Transform item  in blueBecaons.transform)
            {
                // Adds each blue becaon to the hashtable, and turns off the red display
                dictOfBeacons.Add(item.gameObject, false);
				redBeacons.SetActive(false);
            }
			Debug.Log("On the Red Team, find the blue beacons");
        }
        // Sets the target beacons to the red team, is on blue
        else
        {
            foreach (Transform item in redBeacons.transform)
            {
                dictOfBeacons.Add(item.gameObject, false);
                blueBecaons.SetActive(false);
            }
			Debug.Log("On the Blue Team, find the red beacons");
        }
    }
}
