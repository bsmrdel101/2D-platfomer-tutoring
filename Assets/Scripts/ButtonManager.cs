using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnClickPlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
