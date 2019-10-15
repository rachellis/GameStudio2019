using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for the prototype from 10/9 - 10/16
/// </summary>
public class Prototype : MonoBehaviour
{
    public GameObject playerPanel;

    public GameObject towerPanel;
    /// <summary>
    /// Called when the player is captured
    /// </summary>
    public void capturePlayer()
    {
        playerPanel.SetActive(true);

        Invoke("deactivate", 4f);
        
        
    }

    /// <summary>
    /// Called when the player captures the tower
    /// </summary>
    public void captureTower()
    {
        towerPanel.SetActive(true);

        Invoke("deactivate", 4f);

    }

    public void deactivate()
    {
        playerPanel.SetActive(false);

        towerPanel.SetActive(false);
    }
}
