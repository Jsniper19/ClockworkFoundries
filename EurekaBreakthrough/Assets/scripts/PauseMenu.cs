using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseUI;


    void Update()
    {
        if (paused)
        {
            pauseUI.SetActive(true);
        }
        else if (!paused)
        {
            pauseUI.SetActive(false);
        }
    }

    void Quit()
    {
        Application.Quit();
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return false;
        }
        else
        {
            Time.timeScale = 0f;
            return true;
        }
    }
}
