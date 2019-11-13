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

    private bool hasBeenCaught = false;

    public void capturePlayer(GameObject player)
    {
        player.SetActive(true);

        StartCoroutine(deactivate(player, wait));


    }

    /// <summary>
    /// Called when the player captures the tower
    /// </summary>
    public void captureTower(GameObject tower)
    {
        capturePointBadge.SetActive(true);

    }

    public IEnumerator deactivate(GameObject obj,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    // Lock Button press
    public void CaptureSystem(Button captureButton)
    {
        if (hasBeenCaught)
        {

            hasBeenCaught = false;
        }
        else
        {
            capturePointBadge.SetActive(false);
            hasBeenCaught = true;
        }
    }
}
