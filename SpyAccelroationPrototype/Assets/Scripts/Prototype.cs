using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used for the prototype from 10/9 - 10/16
/// </summary>
public class Prototype : MonoBehaviour
{
    /// <summary>
    /// Called when the player is captured
    /// </summary>
    ///

    public float wait = 4f;

    public GameObject capturePointBadge;

    public GameObject redBeacons;
    public GameObject blueBecaons;

    public GameObject homeBeacon;

    public List<GameObject> listOfRedBeacons;

    public List<GameObject> listOfBlueBeacons;

    public List<GameObject> listOfDisplays;

    private bool hasBeenCaught = false;

    private int numOfBeacons = 0;

    private Hashtable dictOfBeacons = new Hashtable();

    public void capturePlayer(GameObject player)
    {
        player.SetActive(true);

        StartCoroutine(deactivate(player, wait));


    }

    /// <summary>
    /// Called when the player captures the tower
    /// </summary>
    public void captureTower(GameObject beacon)
    {
        dictOfBeacons[beacon] = true;
        numOfBeacons++;
        displayBeacons(numOfBeacons);

    }

    public IEnumerator deactivate(GameObject obj,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }


    public void beenCaputred()
    {
        foreach (KeyValuePair<GameObject,bool> kvp in dictOfBeacons)
        {
            dictOfBeacons[kvp.Key] = false;
        }
        numOfBeacons = 0;
        displayBeacons(numOfBeacons);
    }

    private void displayBeacons(int numDisplay)
    {
        for (int i = 0; i < numDisplay; i++)
        {
            listOfDisplays[i].SetActive(true);
        }
    }

    public void setTeam(bool isRedTeam)
    {
        if (isRedTeam)
        {
            foreach (var item  in listOfBlueBeacons)
            {
                dictOfBeacons.Add(item, false);
                redBeacons.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject item in listOfRedBeacons)
            {
                dictOfBeacons.Add(item, false);
                blueBecaons.SetActive(false);
            }
        }
    }
}
