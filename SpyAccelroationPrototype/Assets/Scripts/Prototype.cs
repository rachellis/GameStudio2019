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

    public Color caughtColor;
    public Color SafeColor;

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
        tower.SetActive(true);
        capturePointBadge.SetActive(true);
        StartCoroutine(deactivate(tower, wait));

    }

    public IEnumerator deactivate(GameObject obj,float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        obj.SetActive(false);
    }

    public void CaptureSystem(Button captureButton)
    {
        Text captureButtonText = captureButton.GetComponentInChildren(typeof(Text)) as Text;
        if (hasBeenCaught)
        {
            captureButtonText.text = "I've been caught";
            captureButton.GetComponent<Image>().color = caughtColor;
            hasBeenCaught = false;
        }
        else
        {
            captureButtonText.text = "I'm at base";
            captureButton.GetComponent<Image>().color = SafeColor;
            capturePointBadge.SetActive(false);
            hasBeenCaught = true;
        }
    }
}
