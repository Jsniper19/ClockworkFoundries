using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;
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

    public void Quit()
    {
        Application.Quit();
    }

    bool TogglePause()
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

    public void PauseButton(){
        paused = TogglePause();
    }
}
