using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// Changes from the start menu to the main game
    /// </summary>
    public void changeToGame()
    {
        SceneManager.LoadScene("InApp");
    }

    public void goHome()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
