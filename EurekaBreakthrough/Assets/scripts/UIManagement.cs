using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public Slider Health;
    public Slider Initiative;

    public PlayerController_Combat Future;
    public PlayerController_Combat Present;
    public PlayerController_Combat Set;

    private void Start()
    {
        Health.maxValue = Set.maxHealth;
        Initiative.maxValue = Set.maxInitiative;
    }

    // Update is called once per frame
    void Update()
    {
        Health.value = Set.currentHealth;
        Initiative.value = Set.currentInitiative;
    }
}
