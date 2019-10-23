using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for the prototype from 10/9 - 10/16
/// </summary>
public class Prototype : MonoBehaviour
{
    /// <summary>
    /// Called when the player is captured
    /// </summary>
    public void capturePlayer(GameObject player)
    {
        player.SetActive(true);

        StartCoroutine(deactivate(player, 4f));


    }

    /// <summary>
    /// Called when the player captures the tower
    /// </summary>
    public void captureTower(GameObject tower)
    {
        tower.SetActive(true);

        StartCoroutine(deactivate(tower, 4f));

    }

    public IEnumerator deactivate(GameObject obj,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        obj.SetActive(false);
    }
}
