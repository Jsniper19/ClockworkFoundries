using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public int tutNo = 0;

    public Text tutorialText;

    public GameObject tutorialParent;

    void Awake()
    {
        tutorialParent.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !PauseMenu.paused)
        {
            tutNo++;
        }

        switch (tutNo)
        {
            case 0:
                {
                    tutorialText.text = "[Left Click] the buttons around the player to move";
                }
                break;
            case 1:
                {
                    tutorialText.text = "[Left Click] an enemy to attack";
                }
                break;
            case 2:
                {
                    tutorialText.text = "These attacks can crit or miss, the damage will be shown above their head";
                }
                break;
            case 3:
                {
                    tutorialText.text = "Your actions cost initative, displayed by the blue bar";
                }
                break;
            case 4:
                {
                    tutorialText.text = "Your objective is to defeat all the British Red Coats";
                }
                break;
            case 5:
                {
                    tutorialText.text = "You however, are a time traveller and can press the [Blue Button] to time travel";
                }
                break;
            case 6:
                {
                    tutorialText.text = "Now you can help your past self in combat!";
                }
                break;
            case 7:
                {
                    tutorialText.text = "To swap between players, click the [Swap Self] button";
                }
                break;
            case 8:
                {
                    tutorialText.text = "You're all set! defeat all the Red Coats to win!";
                }
                break;
            case 9:
                {
                    Destroy(tutorialParent);
                }
                break;
        }
    }
}