using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverworldInteraction : MonoBehaviour
{
    public bool isEngage;
    public Text InteractText;
    public GameObject InteractPanel;
    public Button InteractButton;
    public Button CancelButton;
    public PlayerController_Overworld PCO;
    public GameObject ActiveItem;
    public GameObject InactiveItem;
    public bool Active;

    private void Start()
    {
        PCO = GameObject.Find("Character").gameObject.GetComponent<PlayerController_Overworld>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PCO.PLAY = false;
            InteractButton.onClick.AddListener(Interact);
            CancelButton.onClick.AddListener(CancelInteract);
            InteractPanel.SetActive(true);
            if (isEngage)
            {
                InteractText.text = "Engage";
            }
            else
            {
                InteractText.text = "Interact";
            }
        }
    }


    public void Interact()
    {
        if (isEngage)
        {
            SceneManager.LoadScene("Combat");
        }
        else
        {
            if (!Active)
            {
                Debug.Log("Something should be happening");
                InactiveItem.SetActive(false);
                ActiveItem.SetActive(true);
                Active = true;
            }
            else
            {
                Debug.Log("Something should be happening");
                InactiveItem.SetActive(true);
                ActiveItem.SetActive(false);
                Active = false;
            }
        }
    }

    public void CancelInteract()
    {
        InteractButton.onClick.RemoveListener(Interact);
        CancelButton.onClick.RemoveListener(CancelInteract);
        InteractPanel.SetActive(false);
        PCO.PLAY = true;
    }
}
