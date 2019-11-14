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
		bool test = (bool)dictOfBeacons[beacon];
		if (test == false)
		{
			dictOfBeacons[beacon] = true;
			numOfBeacons++;
			displayBeacons(numOfBeacons);
		}

    }

    public IEnumerator deactivate(GameObject obj,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }


    public void beenCaputred()
    {
		Hashtable temp = new Hashtable();
		temp = (Hashtable)dictOfBeacons.Clone();

        foreach(GameObject obj in temp.Keys)
		{
			dictOfBeacons[obj] = false;
		}

        numOfBeacons = 0;
        displayBeacons(numOfBeacons);
    }

    private void displayBeacons(int numDisplay)
    {
		for (int i = 0; i < listOfDisplays.Count; i++)
		{
			listOfDisplays[i].SetActive(false);
		}
        for (int i = 0; i < numDisplay; i++)
        {
            listOfDisplays[i].SetActive(true);
        }
    }

    public void setTeam(bool isRedTeam)
    {
        if (isRedTeam)
        {
            foreach (Transform item  in blueBecaons.transform)
            {
                dictOfBeacons.Add(item.gameObject, false);
				redBeacons.SetActive(false);
            }
			Debug.Log("On the Red Team, find the blue beacons");
        }
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
