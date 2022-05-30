using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapActivePlayer : MonoBehaviour
{
    public GameObject CameraPresent;
    public GameObject CameraFuture;
    public PlayerController_Combat PCCPresent;
    public PlayerController_Combat PCCFuture;
    public MovementArrows MA;
    public UIManagement UIM;

    public bool present;

    public void SwapPlayer()
    {
        if (!present)
        {
            CameraPresent.SetActive(true);
            CameraFuture.SetActive(false);
            PCCPresent.isSelected = true;
            PCCFuture.isSelected = false;
            MA.PCC = MA.Present;
            UIM.Set = UIM.Present;
            MA.ResetTarget();
            present = true;
        }
        else
        {
            CameraFuture.SetActive(true);
            CameraPresent.SetActive(false);
            PCCPresent.isSelected = false;
            PCCFuture.isSelected = true;
            MA.PCC = MA.Future;
            UIM.Set = UIM.Future;
            MA.ResetTarget();
            present = false;
        }
    }
}
