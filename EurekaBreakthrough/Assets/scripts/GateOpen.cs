using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public GameObject LeverOpen;
    public GameObject ClosedGate;
    public GameObject OpenGate;

    private void Update()
    {
        if (LeverOpen.activeInHierarchy)
        {
            ClosedGate.SetActive(false);
            OpenGate.SetActive(true);
        }
        else
        {
            ClosedGate.SetActive(true);
            OpenGate.SetActive(false);
        }
    }
}
