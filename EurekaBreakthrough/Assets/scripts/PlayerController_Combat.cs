using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Combat : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public int maxInitiative;
    public int currentInitiative;
    public bool isPresent;
    public float timeMeter;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentInitiative = maxInitiative;
    }

    void TestFunction()
    {
        int initiativeCost = 1;
        currentInitiative -= initiativeCost;

        Debug.Log("Selection Successful");
    }
}
